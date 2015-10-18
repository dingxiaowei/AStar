using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AStar
{
	struct matrix
	{
		public int x, y;
		public matrix(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	};
	class Astar
	{
		private static Dictionary<string, Node> obstancleDic;
		//private static Dictionary<string, Node> routeList;
		private static Dictionary<string, Node> openDic = new Dictionary<string, Node>();
		private static Dictionary<string, Node> clostDic = new Dictionary<string, Node>();
		private matrix Matrix;
		private Node startNode, endNode;
		private Node currentNode;

		public Node getStartNode()
		{
			return this.startNode;
		}

		public Node getEndNode()
		{
			return this.endNode;
		}


		public Astar(Node startnode, Node endnode, matrix Ma, Dictionary<string, Node> obstacal)
		{
			this.startNode = startnode;
			this.endNode = endnode;
			this.Matrix = Ma;
			obstancleDic = obstacal;
		}

		public void AStar()
		{
			Node tempNode = new Node();
			Node temp = new Node();

			currentNode = this.getStartNode();
			openDic.Add(currentNode.getKey(), currentNode);
			do
			{
				for (int i = 0; i < 3; i++)
				{
					for (int j = 0; j < 3; j++)
					{
						tempNode.X = currentNode.X + i - 1;
						tempNode.Y = currentNode.Y + j - 1;

						if (!obstancleDic.ContainsKey(tempNode.getKey()) && !clostDic.ContainsKey(tempNode.getKey()) && tempNode.X >= 0 && tempNode.X <= Matrix.x && tempNode.Y >= 0 && tempNode.Y <= Matrix.y && (i != 1 || j != 1))
						{
							if (openDic.TryGetValue(tempNode.getKey(), out temp))
							{
								int gF = temp.getG(temp.getFather());
								int gC = temp.getG(currentNode);
								if (gF > gC)
								{
									temp.setFather(currentNode);
								}
							}
							else
							{
								tempNode.setFather(currentNode);
								openDic.Add(tempNode.getKey(), tempNode);
							}
							tempNode = new Node();
						}
					}
				}
				openDic.Remove(currentNode.getKey());
				clostDic.Add(currentNode.getKey(), currentNode);
				currentNode = this.getMinNode(openDic, this.getEndNode());
			} while (!clostDic.ContainsKey(this.getEndNode().getKey()) && openDic.Count != 0);
		}

		public void getShortCutRoute()
		{
			Node endNode = new Node();
			if (clostDic.TryGetValue(this.getEndNode().getKey(), out endNode))
			{
				endNode.showShortCutRout();
			}
		}

		private Node getMinNode(Dictionary<string, Node> inputNodeDic, Node endNode)
		{
			Node minNode = new Node();
			if (inputNodeDic.Count > 0)
			{
				minNode = inputNodeDic.ElementAt(0).Value;

				foreach (KeyValuePair<string, Node> item in inputNodeDic)
				{
					if (minNode.getF(endNode) > item.Value.getF(endNode))
					{
						minNode = item.Value;
					}
				}
			}

			return minNode;
		}



	}
}
