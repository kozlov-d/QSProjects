﻿using System;
using System.Linq;
using System.Linq.Expressions;
using NHibernate;
using NHibernate.Criterion;
using QS.DomainModel.Entity;
using QS.DomainModel.UoW;
using QS.Navigation;
using QS.Project.Domain;
using QS.Project.Journal.DataLoader;
using QS.Project.Journal.Search;
using QS.Project.Journal.Search.Criterion;
using QS.Project.Services;
using QS.Services;
using QS.Utilities.Text;
using QS.ViewModels.Dialog;

namespace QS.Project.Journal
{
	public abstract class EntityJournalViewModelBase<TEntity, TEntityViewModel, TNode, TSearchModel> : JournalViewModelBase
		where TEntity : class, IDomainObject
		where TEntityViewModel : DialogViewModelBase
		where TNode : class
		where TSearchModel : CriterionSearchModelBase
	{
		#region Обязательные зависимости
		#endregion
		#region Опциональные зависимости
		protected IDeleteEntityService DeleteEntityService; //Опционально аналогично предыдущиему сервису.

		public ICurrentPermissionService CurrentPermissionService { get; set; }
		#endregion

		protected EntityJournalViewModelBase(
			IUnitOfWorkFactory unitOfWorkFactory,
			IInteractiveService interactiveService,
			INavigationManager navigationManager,
			SearchViewModelBase<TSearchModel> searchViewModel,
			IDeleteEntityService deleteEntityService = null,
			ICurrentPermissionService currentPermissionService = null
			) : base(unitOfWorkFactory, interactiveService, navigationManager)
		{
			NavigationManager = navigationManager;
			CriterionSearchViewModel = searchViewModel ?? throw new ArgumentNullException(nameof(searchViewModel));
			//SetCriterionSearch(criterionSearch ?? throw new ArgumentNullException(nameof(criterionSearch)));
			CurrentPermissionService = currentPermissionService;
			DeleteEntityService = deleteEntityService;

			var dataLoader = new ThreadDataLoader<TNode>(unitOfWorkFactory);
			dataLoader.CurrentPermissionService = currentPermissionService;
			dataLoader.AddQuery<TEntity>(ItemsQuery);
			DataLoader = dataLoader;

			if(currentPermissionService != null && !currentPermissionService.ValidateEntityPermission(typeof(TEntity)).CanRead)
				throw new AbortCreatingPageException($"У вас нет прав для просмотра документов типа: {typeof(TEntity).GetSubjectName()}", "Невозможно открыть журнал");

			CreateNodeActions();

			var names = typeof(TEntity).GetSubjectNames();
			if(!String.IsNullOrEmpty(names?.NominativePlural))
				TabName = names.NominativePlural.StringToTitleCase();

			UpdateOnChanges(typeof(TEntity));
		}

		protected override void CreateNodeActions()
		{
			base.CreateNodeActions();

			bool canCreate = CurrentPermissionService == null || CurrentPermissionService.ValidateEntityPermission(typeof(TEntity)).CanCreate;
			bool canEdit = CurrentPermissionService == null || CurrentPermissionService.ValidateEntityPermission(typeof(TEntity)).CanUpdate;
			bool canDelete = CurrentPermissionService == null || CurrentPermissionService.ValidateEntityPermission(typeof(TEntity)).CanDelete;

			var addAction = new JournalAction("Добавить",
					(selected) => canCreate,
					(selected) => true,
					(selected) => CreateEntityDialog()
					);
			NodeActionsList.Add(addAction);

			var editAction = new JournalAction("Изменить",
					(selected) => canEdit,
					(selected) => true,
					(selected) => selected.Cast<TNode>().ToList().ForEach(EditEntityDialog)
					);
			NodeActionsList.Add(editAction);

			if(SelectionMode == JournalSelectionMode.None)
				RowActivatedAction = editAction;

			var deleteAction = new JournalAction("Удалить",
					(selected) => canDelete,
					(selected) => true,
					(selected) => DeleteEntities(selected.Cast<TNode>().ToArray())
					);
			NodeActionsList.Add(deleteAction);
		}

		/// <summary>
		/// Функция формирования запроса.
		/// ВАЖНО: Необходимо следить чтобы в запросе не было INNER JOIN с ORDER BY и LIMIT.
		/// Иначе запрос с LIMIT будет выполнятся также медленно как и без него.
		/// В таких случаях необходимо заменять на другой JOIN и условие в WHERE
		/// </summary>
		protected abstract IQueryOver<TEntity> ItemsQuery(IUnitOfWork uow);

		protected virtual void CreateEntityDialog()
		{
			NavigationManager.OpenViewModel<TEntityViewModel, IEntityUoWBuilder>(this, EntityUoWBuilder.ForCreate());
		}

		protected virtual void EditEntityDialog(TNode node)
		{
			NavigationManager.OpenViewModel<TEntityViewModel, IEntityUoWBuilder>(this, EntityUoWBuilder.ForOpen(DomainHelper.GetId(node)));
		}

		protected virtual void DeleteEntities(TNode[] nodes)
		{
			foreach(var node in nodes)
				DeleteEntityService.DeleteEntity<TEntity>(DomainHelper.GetId(node));
		}

		#region Поиск

		protected SearchViewModelBase<TSearchModel> CriterionSearchViewModel { get; private set; }

		public override SearchViewModelBase SearchViewModel => CriterionSearchViewModel;

		protected TSearchModel CriterionSearchModel => CriterionSearchViewModel.SearchModelGeneric;

		[Obsolete("Заменить на обращение к CriterionSearchModel. В водовозе не используется")]
		protected ICriterion GetSearchCriterion(params Expression<Func<object>>[] aliasPropertiesExpr)
		{
			if(CriterionSearchModel == null) {
				return new Conjunction();
			}

			return CriterionSearchModel.ConfigureSearch()
				.AddSearchBy(aliasPropertiesExpr)
				.GetSearchCriterion();
		}

		[Obsolete("Заменить на обращение к CriterionSearchModel. В водовозе не используется")]
		protected ICriterion GetSearchCriterion<TRootEntity>(params Expression<Func<TRootEntity, object>>[] propertiesExpr)
		{
			if(CriterionSearchModel == null) {
				return new Conjunction();
			}

			return CriterionSearchModel.ConfigureSearch()
				.AddSearchBy(propertiesExpr)
				.GetSearchCriterion();
		}

		#endregion
	}
}
