﻿using System;
using System.Collections.Generic;
using Gtk;
using System.Reflection;

namespace Gamma.GtkWidgets.Cells
{
	public class NodeCellRendererSpin<TNode> : CellRendererSpin, INodeCellRenderer
	{
		public List<Action<NodeCellRendererSpin<TNode>, TNode>> LambdaSetters = new List<Action<NodeCellRendererSpin<TNode>, TNode>>();

		public string DataPropertyName { get{ return DataPropertyInfo.Name;
			}}

		public PropertyInfo DataPropertyInfo { get; set;}

		public NodeCellRendererSpin ()
		{
		}

		public void RenderNode(object node)
		{
			if(node is TNode)
			{
				var typpedNode = (TNode)node;
				LambdaSetters.ForEach (a => a.Invoke (this, typpedNode));
			}
		}
	}
}

