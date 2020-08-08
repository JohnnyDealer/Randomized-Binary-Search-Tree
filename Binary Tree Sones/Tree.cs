using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomized_Binary_Search_Tree.Binary_Tree_Sones
{
    class Tree
    {
        private Sones sones = new Sones();
        public void Add(int key)
        {
           // sones.Add(key);
            sones.Get_Tree().RandomAdd(key);
        }
        public void Print(bool brackets)
        {
            BinaryTree tree = sones.Get_Tree();
            tree.Print_First(brackets);
        }
        public void Show()
        {
            sones.ViewList();
        }
        public void Bypass(string str)
        {
            BinaryTree tree = sones.Get_Tree();            
            tree.Show(str);
        }
        public static void Execute(Tree A, Tree B)
        {
            BinaryTree.Elimination(A.sones.Get_Tree(), B.sones.Get_Tree());
        }
        public void Delete(int key)
        {
            sones.Get_Tree().Delete(key);
        }
           
    }
}
