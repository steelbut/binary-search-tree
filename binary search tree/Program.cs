using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoritmer
{
    public class Program
    {
        public class TreeNode
        {
            public int Score { get; set; }
            public List<TreeNode> Children { get; set; } = new List<TreeNode>();

            public TreeNode(int score)
            {
                Score = score;
            }
        }

        public class DecisionTree
        {
            public TreeNode Root { get; }

            public DecisionTree(int rootScore)
            {
                Root = new TreeNode(rootScore);
            }
        }

        public static void Main()
        {
            DecisionTree decisionTree = new DecisionTree(0);
            TreeNode stayNode = new TreeNode(2);
            TreeNode moveNode = new TreeNode(8);
            
            decisionTree.Root.Children.Add(stayNode);
            decisionTree.Root.Children.Add(moveNode);

            TreeNode child1 = new TreeNode(5);
            TreeNode child2 = new TreeNode(7);
            stayNode.Children.Add(child1);
            stayNode.Children.Add(child2);

            TreeNode child3 = new TreeNode(3);
            TreeNode child4 = new TreeNode(6);
            moveNode.Children.Add(child3);
            moveNode.Children.Add(child4);

            TreeNode bestMove = FindBestMove(decisionTree.Root);
            Console.WriteLine("Best Move Score: " + bestMove.Score);
            Console.ReadKey();
        }

        public static TreeNode FindBestMove(TreeNode currentNode)
        {
            if (currentNode.Children.Count == 0)
            {
                return currentNode; 
            }

            TreeNode bestChild = null;
            int bestScore = int.MaxValue;

            foreach (var child in currentNode.Children)
            {
                TreeNode childResult = FindBestMove(child);
                if (childResult.Score < bestScore)
                {
                    bestScore = childResult.Score;
                    bestChild = child;
                }
            }
            return bestChild;
        }
       
    }
}
