using System;


class Node //узел
{
    public double value;
    public Node left;
    public Node right;
}

class BinaryTree //дерево
{
    private Node root;

    public void Insert(double value) //вставка элемента в дерево
    {
        Node node = new Node();
        node.value = value;

        if (root == null)
        {
            root = node;
            return;
        }

        Node current = root;

        while (true)
        {
            if (value < current.value)
            {
                if (current.left == null)
                {
                    current.left = node;
                    return;
                }
                else
                {
                    current = current.left;
                }
            }
            else
            {
                if (current.right == null)
                {
                    current.right = node;
                    return;
                }
                else
                {
                    current = current.right;
                }
            }
        }
    }

    public Node Find(double value) //найти элемент в дереве
    {
        Node current = root;

        while (current != null)
        {
            if (current.value == value)
            {
                return current;
            }
            else if (value < current.value)
            {
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }

        return null;
    }

    public Node FindWithPrint(double value) //вывести путь до нужного узла
    {
        Node current = root;
        string path = "";

        while (current != null)
        {
            if (current.value == value)
            {
                Console.WriteLine("Путь к элементу: " + path + current.value);
                return current;
            }
            else if (value < current.value)
            {
                path += current.value + " -> ";
                current = current.left;
            }
            else
            {
                path += current.value + " -> ";
                current = current.right;
            }
        }

        return null;
    }

    private void PrintTree(Node current, string indent, bool last) //вывод дерева на экран
    {
        Console.Write(indent);

        if (last)
        {
            Console.Write("`R:--  ");
            indent += "    ";
        }
        else
        {
            Console.Write("|L:--  ");
            indent += "|  ";
        }

        Console.WriteLine(current.value);

        if (current.left != null)
        {
            PrintTree(current.left, indent, current.right == null);
        }

        if (current.right != null)
        {
            PrintTree(current.right, indent, true);
        }
    }

    public void Print() //запуск печати дерева
    {
        if (root != null)
        {
            PrintTree(root, "", true);
        }
    }
}
class Program
{
    static void Main(string[] args) //основной метод
    {
        Program.BinaryTree();
    }
    static void BinaryTree() //метод работы с деревом
    {
        BinaryTree tree = new BinaryTree();
        int a = 0;
        double mu, sig;
        Console.WriteLine("Введите M:");
        mu = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Введите S:");
        sig = Convert.ToDouble(Console.ReadLine());
        Random r1 = new Random();
        Random r2 = new Random();
        for (int i = 0; i < 30; i++)
        {
            double x = Math.Sqrt(-2.0 * Math.Log(r1.NextDouble())) * Math.Cos(2 * Math.PI * r2.NextDouble()); //преобразование Бокса-Мюллера
            double y = Math.Round(mu + sig * x, 3);
            tree.Insert(y);
            a++;
        }
        Console.WriteLine("Количество вершин: " + Convert.ToString(a));
        Console.WriteLine("Дерево:");
        tree.Print();
        while (true)
        {
            Console.WriteLine("Введите значение для поиска:");
            double searchValue = double.Parse(Console.ReadLine());
            Node result = tree.FindWithPrint(searchValue);
            if (result == null)
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine("Элемент найден: " + result.value);
            }
            Console.WriteLine("Enter - продолжить, Escape - выйти, Backspace - перезапуск дерева");
            var input = Console.ReadKey();
            if (input.Key == ConsoleKey.Escape) //закончить выполнение
            {
                break;
            }
            else if (input.Key == ConsoleKey.Enter) //продолжить работу с данным деревом
                continue;
            else if (input.Key == ConsoleKey.Backspace) //перезапустить дерево
            {
                Console.Clear();
                Program.BinaryTree();
            }
        }
    }
}