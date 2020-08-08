using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomized_Binary_Search_Tree
{
    class BinaryTreeNode
    {
        public BinaryTreeNode left;
        public BinaryTreeNode right;
        public int key;
        public int size;
        public BinaryTreeNode(int key)
        {
            this.key = key;
            this.size = 1;
            this.left = null;
            this.right = null; 
        }
    }
}
