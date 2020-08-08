using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Randomized_Binary_Search_Tree.Binary_Tree_Sones
{
    class Sones
    {
        private List<List<BinaryTreeNode>> sones = new List<List<BinaryTreeNode>>();
        private BinaryTree tree = new BinaryTree();
        public void Add(int key)
        {
            if (Contains(key))
            {
               
                return;
            }
               // Console.WriteLine("Элемент уже есть!");
            else
            {
                Add_To_List(sones, key);
            }
        }
        private void Add_To_List(List<List<BinaryTreeNode>> list, int key)
        {
            
            BinaryTreeNode node = new BinaryTreeNode(key);
            if (list.Count() == 0)
            {
                
                for(int i = 0; i < 3; i++)
                {
                    list.Add(new List<BinaryTreeNode>());
                    for(int j = 0; j < 3; j++)                    
                        list[i].Add(null);
                    
                }
                list[0][0] = node;
                list.Clear();
            }
            else
            {
                bool finished = false;
                int iterator = 0;
                int parent = 0;
                int leftSon = 1;
                int rightSon = 2;
                int to_find = list[0][0].key;
                while (!finished)
                {
                    iterator = Find(to_find);
                    if (list[iterator][parent] != null)
                    {
                        if (node.key > list[iterator][parent].key)
                        {
                            if (list[iterator][rightSon] == null)
                            {
                                while(sones.Count() < (iterator * 2 + 3))
                                    list.Add(new List<BinaryTreeNode>() { null, null, null });
                                list[iterator * 2 + 2][0] = node;                                
                                list[iterator][rightSon] = node;
                                tree.RandomAdd(key);
                                finished = true;
                            }
                            else
                                to_find = list[iterator][rightSon].key;
                        }
                        else
                        {
                            if (list[iterator][leftSon] == null)
                            {
                                while (sones.Count() < (iterator * 2 + 2))
                                    list.Add(new List<BinaryTreeNode>() { null, null, null });
                                list[iterator * 2 + 1][0] = node;
                                list[iterator][leftSon] = node;
                                tree.RandomAdd(key);
                                finished = true;
                            }
                            else
                                to_find = list[iterator][leftSon].key;
                        }
                    }
                }
            }
            tree.RandomAdd(key);
        }
        private int Find(int key)
        {
            int result = 0;
            for (int i = 0; i < sones.Count(); i++)
            {
                if (sones[i][0] == null)
                    continue;
                if (sones[i][0].key == key)
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
        private bool Contains(int key)
        {
            bool result = false;
            for(int i = 0; i < sones.Count(); i++)
            {
                if (sones[i][0] == null)
                    continue;
                if (sones[i][0].key == key)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public void ViewList()
        {
            Console.WriteLine("Список сыновей:");
            Var_Second();
            Var_First();
        }
        public BinaryTree Get_Tree()
        {
            return this.tree;
        }
        private void Var_First()
        {
            for (int i = 0; i < sones.Count(); i++)
            {
                if (sones[i][0] == null)
                    continue;
                for (int j = 0; j < sones[i].Count(); j++)
                {

                    if (sones[i][j] == null)
                        Console.Write("null" + "\t");
                    else
                        Console.Write(sones[i][j].key + "\t");
                }
                Console.WriteLine();
            }
        }
        private void Var_Second()
        {
            BinaryTree tree = Get_Tree();
            List<int> keys = new List<int>();
            tree.Get_Elements_Direct(keys);
            int size = tree.Root.size;
            for (int i = 0; i < size; i++)
                sones.Add(new List<BinaryTreeNode>() { null, null, null });
            for(int i = 0; i < size; i++)
            {
                sones[i][0] = tree.Find_Node(tree.Root, keys[i]);
                sones[i][1] = sones[i][0].left;
                sones[i][2] = sones[i][0].right;
            }
        }
    }
}
