﻿using System;
using System.Collections.Generic;
using QS.DomainModel.UoW;
using QS.Project.Domain;
using QS.Project.Repositories;

namespace QS.EntityRepositories
{
	public class UserPermissionSingletonRepository : IUserPermissionRepository
	{
		private static UserPermissionSingletonRepository instance;

		public static UserPermissionSingletonRepository GetInstance()
		{
			if(instance == null)
				instance = new UserPermissionSingletonRepository();
			return instance;
		}

		protected UserPermissionSingletonRepository() { }

		public EntityUserPermission GetUserEntityPermission(IUnitOfWork uow, string entityName, int userId)
		{
			TypeOfEntity typeOfEntityAlias = null;
			EntityUserPermission entityUserPermissionAlias = null;
			UserBase userBaseAlias = null;
			return uow.Session.QueryOver<EntityUserPermission>(() => entityUserPermissionAlias)
				.Left.JoinAlias(() => entityUserPermissionAlias.User, () => userBaseAlias)
				.Left.JoinAlias(() => entityUserPermissionAlias.TypeOfEntity, () => typeOfEntityAlias)
				.Where(() => userBaseAlias.Id == userId)
				.Where(() => typeOfEntityAlias.Type == entityName)
				.SingleOrDefault();
		}

		public IList<EntityUserPermission> GetUserAllEntityPermissions(IUnitOfWork uow, int userId)
		{
			return uow.Session.QueryOver<EntityUserPermission>()
				.Where(x => x.User.Id == userId)
				.List();
		}

		public IList<PresetUserPermission> GetUserAllPresetPermissions(IUnitOfWork uow, int userId)
		{
			return uow.Session.QueryOver<PresetUserPermission>()
				.Where(x => x.User.Id == userId)
				.List();
		}

		private IReadOnlyDictionary<string, bool> currentUserPresetPermissions;
		public IReadOnlyDictionary<string, bool> CurrentUserPresetPermissions {
			get {
				if(currentUserPresetPermissions == null) {
					using(var uow = UnitOfWorkFactory.CreateWithoutRoot()) {
						var currentUser = UserRepository.GetCurrentUser(uow);
						currentUser.LoadUserPermissions();
						currentUserPresetPermissions = currentUser.Permissions;
					}
				}
				return currentUserPresetPermissions;
			}
		}
	}
}