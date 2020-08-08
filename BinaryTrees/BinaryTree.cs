using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Randomized_Binary_Search_Tree
{
    class BinaryTree
    {        
        private BinaryTreeNode root;
        public static int N_op = 0;
        private static Random rand = new Random();
        public BinaryTreeNode Root { get { return root; } }
        public BinaryTree()
        {
            this.root = null;
        }

        public void Add_Test(int key)
        {
            if (Contains(key))
                return;
            else
            {
                if (root == null)
                {
                    N_op++;
                    this.root = new BinaryTreeNode(key);
                }
                    
                else
                {
                    this.root = Insert_Node_Test(root, key);
                }
            }
        }
        public void Add(int key)             
        {
            if (Contains(key))
                return;
            else
            {
                if (root == null)              
                    this.root = new BinaryTreeNode(key);
                else
                    this.root = Insert_Node(root, key);
            }         
        }
        public void RandomAdd(int key)
        {
            if (Contains(key))
                return;
            else
            {
                if (root == null)                   
                    this.root = new BinaryTreeNode(key);
                else
                    this.root = Randomized_Insert_Test(root, key);
            }
            
        }
        public void Find_Test(int key)
        {
            N_op = 0;
            BinaryTreeNode temp = Find_Node_Test(Root, key);
            if (temp == null)
                Console.WriteLine("Данного элемента нет в дереве!");
            else
                Console.WriteLine($"Нужный элемент ({temp.key}) найден!");
        }
        public void Find(int key)
        {
            BinaryTreeNode temp = Find_Node(Root, key);
            if (temp == null)
                Console.WriteLine("Данного элемента нет в дереве!");
            else
                Console.WriteLine($"Нужный элемент ({temp.key}) найден!");
        }
        public bool Contains(int key)
        {
            BinaryTreeNode temp = Find_Node(root, key);
            if (temp == null)
                return false;
            else
                return true;
        }
        private int GetNodeSize(BinaryTreeNode node)
        {
            if (node == null)
                return 0;
            return node.size;
        }
        private void RefreshSize(BinaryTreeNode node)
        {
            node.size = GetNodeSize(node.left) + GetNodeSize(node.right) + 1;
        }
        private BinaryTreeNode Insert_Node_Test(BinaryTreeNode node, int key)   //Метод для внутреннего рекурсивного добавления узла
        {
            if (node == null)
            {
                N_op++;
                return new BinaryTreeNode(key);
            }
                
            if (key < node.key)
            {
                N_op++;
                node.left = Insert_Node_Test(node.left, key);
            }
                
            else
            {
                N_op++;
                node.right = Insert_Node_Test(node.right, key);
            }
                
            RefreshSize(node); N_op+=2;
            return node;
        }
        private BinaryTreeNode Insert_Node(BinaryTreeNode node, int key)   //Метод для внутреннего рекурсивного добавления узла
        {
            if (node == null)
                return new BinaryTreeNode(key);
            if (key < node.key)
                node.left = Insert_Node(node.left, key);
            else
                node.right = Insert_Node(node.right, key);
            RefreshSize(node);
            return node;
        }
        public BinaryTreeNode Find_Node_Test(BinaryTreeNode node, int key)
        {
            if (node == null)
            {
                N_op++;
                return null;
            }
            if (key == node.key)
            {
                N_op++;
                return node;
            }             
            if (key < node.key)
            {
                N_op++;
                return Find_Node_Test(node.left, key);
            }
            else
            {
                N_op++;
                return Find_Node_Test(node.right, key);
            }
                
        }
        public BinaryTreeNode Find_Node(BinaryTreeNode node, int key)
        {
            if (node == null)
            {
                return null;
            }
            if (key == node.key)
                return node;
            if (key < node.key)
                return Find_Node(node.left, key);
            else
                return Find_Node(node.right, key);
        }
        private BinaryTreeNode Find_Parent_Node(BinaryTreeNode node, int key)
        {
            if(key == Root.key)
            {
                return null;
            }
            else
            {
                if (node.left != null && node.right != null)
                {
                    if (node.left.key != key && node.right.key != key)
                    {
                        if (key < node.key)
                            return Find_Parent_Node(node.left, key);
                        else
                            return Find_Parent_Node(node.right, key);
                    }
                    else
                        return node;
                }
                else
                {
                    if (node.left == null)
                    {
                        if (node.right.key != key)
                            return Find_Parent_Node(node.right, key);
                        else
                            return node;
                    }
                    else
                    {
                        if (node.left.key != key)
                            return Find_Parent_Node(node.left, key);
                        else
                            return node;
                    }
                }
            }
                             
        }
        private BinaryTreeNode RotateRight(BinaryTreeNode node)
        {
            BinaryTreeNode newNode = node.left;
            if (newNode == null)
                return node;
            node.left = newNode.right;
            newNode.right = node;           
            RefreshSize(node);
            RefreshSize(newNode);
            return newNode;
        }
        private BinaryTreeNode RotateLeft(BinaryTreeNode node)
        {
            BinaryTreeNode newNode = node.right;
            if (newNode == null)
                return node;
            node.right = newNode.left;
            newNode.left = node;            
            RefreshSize(node);
            RefreshSize(newNode);
            return newNode;
        }
        private BinaryTreeNode Insert_Node_As_Root(BinaryTreeNode node, int key) 
        {
            if (node == null)
                return new BinaryTreeNode(key);
            if (key < node.key)
            {
                node.left = Insert_Node_As_Root(node.left, key);
                return RotateRight(node);
            }
            else
            {
                node.right = Insert_Node_As_Root(node.right, key);
                return RotateLeft(node);
            }
        }
        private BinaryTreeNode Randomized_Insert_Test(BinaryTreeNode node, int key)
        {
            if (node == null)
            {
                N_op++;
                return new BinaryTreeNode(key);
            }
            int random_number = rand.Next();
            int node_size = node.size + 1;
            if ((random_number % node_size) == 0)
                return Insert_Node_As_Root(node, key);
            if (key < node.key)
                node.left = Randomized_Insert_Test(node.left, key);
            else
                node.right = Randomized_Insert_Test(node.right, key);
            RefreshSize(node);
            return node;
        }
        private BinaryTreeNode Randomized_Insert(BinaryTreeNode node, int key)
        {                 
            if (node == null)
                return new BinaryTreeNode(key);
            int random_number = rand.Next();
            int node_size = node.size + 1;           
            if ((random_number % node_size) == 0)
                return Insert_Node_As_Root(node, key);
            if (key < node.key)
                node.left = Randomized_Insert(node.left, key);
            else
                node.right = Randomized_Insert(node.right, key);
            RefreshSize(node);
            return node;
        }
        public void Delete(int key)
        {
            BinaryTreeNode to_delete = Find_Node(Root, key);
            while(to_delete != null)
            {
                Remove(to_delete, key);                
                to_delete = Find_Node(Root, key);    
            }               
        }
        private void Remove(BinaryTreeNode to_delete, int key)
        {
            BinaryTreeNode parent = Find_Parent_Node(Root, key);

            switch (Check_Children(to_delete))
            {
                
                case 0:                    
                    if (parent == null)
                    {
                        root = null;
                    }
                    else
                    {
                        if (parent.key > key)
                            parent.left = null;
                        else
                            parent.right = null;
                        RefreshSize(parent);
                    }
                    break;
                case 1:                    
                    if (parent == null)
                    {
                        if (Root.left == null)
                            root = Root.right;
                        else
                            root = Root.left;
                        RefreshSize(root);
                    }
                    else
                    {
                        if (parent.key > key)
                        {
                            if (to_delete.left == null)
                                parent.left = to_delete.right;
                            else
                                parent.left = to_delete.left;                            
                        }
                        else
                        {
                            if (to_delete.left == null)
                                parent.right = to_delete.right;
                            else
                                parent.right = to_delete.left;                            
                        }
                        RefreshSize(parent);
                    }
                    break;
                case 2:
                    if (parent == null)
                    {

                        BinaryTreeNode maximum = Find_Max(to_delete);
                        if (to_delete.left == maximum)
                        {
                            
                            maximum.right = root.right;
                            root = maximum;
                            RefreshSize(maximum);
                            
                        }
                        else
                        {
                            BinaryTreeNode test;
                            if (maximum.key == to_delete.key)
                                test = Find_Parent_Node(to_delete.left, maximum.key);
                            else
                                test = Find_Parent_Node(Root, maximum.key);
                            test.right = maximum.left;
                            maximum.left = root.left;
                            maximum.right = root.right;
                            root = maximum;
                            RefreshSize(test);
                            RefreshSize(maximum);                           
                        }
                    }
                    else
                    {
                        BinaryTreeNode max = Find_Max(to_delete);
                        if (to_delete.left == max)
                        {
                            if (parent.key > key)
                            {
                                parent.left = max;
                                max.right = to_delete.right;
                            }
                            else
                            {
                                parent.right = max;
                                max.right = to_delete.right;
                            }
                            RefreshSize(max);
                            RefreshSize(parent);

                        }
                        else
                        {
                            Find_Parent_Node(Root, max.key).right = max.left;
                            if (parent.key > key)
                            {
                                parent.left = max;
                                max.left = to_delete.left;
                                max.right = to_delete.right;
                            }
                            else
                            {
                                parent.right = max;
                                max.left = to_delete.left;
                                max.right = to_delete.right;
                            }
                            RefreshSize(max);
                            RefreshSize(parent);                           
                        }
                    }
                    break;
            }

        }
        private BinaryTreeNode Find_Max(BinaryTreeNode node)
        {
            BinaryTreeNode temp = node.left;
            while (temp.right != null)
                temp = temp.right;
            return temp;
        }
        private int Check_Children(BinaryTreeNode node)
        {
            int amount = 0;
            if (node.left != null)
                amount++;
            if (node.right != null)
                amount++;
            return amount;
        }
        public static void Elimination(BinaryTree A, BinaryTree B)
        {
            List<int> temp = new List<int>();
            A.Get_Elements_Direct(temp);
            for (int i = 0; i < temp.Count(); i++)
            {
                if (B.Find_Node(B.Root, temp[i]) == null)                 
                    A.Delete(temp[i]);                             
            }       
        }
        public void Get_Elements_Direct(List<int> list_keys)
        {
            Get_Direct(this.Root, list_keys);
        }
        private void Get_Direct(BinaryTreeNode node, List<int> list_keys)
        {
            if (node == null)
                return;
            list_keys.Add(node.key);
            Get_Direct(node.left, list_keys);
            Get_Direct(node.right, list_keys);
        }
        private void Show_Direct(BinaryTreeNode node)
        {
            if (node == null)
                return;
            Console.Write(node.key + "\t");
            Show_Direct(node.left);
            Show_Direct(node.right);
        }
        private void Show_Symmetrical(BinaryTreeNode node)
        {
            if (node == null)
                return;
            Show_Symmetrical(node.left);
            Console.Write(node.key + "\t");
            Show_Symmetrical(node.right);
        }
        private void Show_Reverse(BinaryTreeNode node)
        {
            if (node == null)
                return;
            Show_Reverse(node.left);
            Show_Reverse(node.right);
            Console.Write(node.key + "\t");
        }
        public void Show(string type = "direct")
        {
            if (type == "direct")
            {
                Console.WriteLine("Прямой обход: ");
                Show_Direct(root);
            }
            if (type == "symmetric")
            {
                Console.WriteLine("Симметричный обход: ");
                Show_Symmetrical(root);
            }             
            if (type == "reverse")
            {
                Console.WriteLine("Обратный обход: ");
                Show_Reverse(root);
            }
            Console.WriteLine();
        }
        public void Print_First()
        {
            Root.Print_A();
        }
        public void Print_First(bool brackets)
        {
            if (brackets)
                Root.Print_A(textFormat: "(0)", spacing: 2);
            else
                Root.Print_A();
            Console.WriteLine();
        }
        public void Print_Second()
        {
            Root.Print_B();
            Console.WriteLine();
        }

    }
}
