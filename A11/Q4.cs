using System;

// Splay tree implementation

// Vertex of a splay tree
public class Vertex
{
  public long key;
  // Sum of all the keys in the subtree - remember to update
  // it after each operation that changes the tree.
  public long sum;
  public Vertex left;
  public Vertex right;
  public Vertex parent;

  public Vertex(long key, long sum, Vertex left, Vertex right, Vertex parent)
  {
	  this.key = key;
	  this.sum = sum;
	  this.left = left;
	  this.right = right;
	  this.parent = parent;
  }
} //????

public static class GlobalMembers
{
	public static void update(Vertex v)
	{
	  if (v == null)
	  {
		return;
	  }
	  v.sum = v.key + (v.left != null ? v.left.sum : 0) + (v.right != null ? v.right.sum : 0);
	  if (v.left != null)
	  {
		v.left.parent = v;
	  }
	  if (v.right != null)
	  {
		v.right.parent = v;
	  }
	}

	public static void small_rotation(Vertex v)
	{ //????
	  Vertex parent = v.parent;
	  if (parent == null)
	  { // v????,????
		return;
	  }
	  Vertex grandparent = v.parent.parent;
	  if (parent.left == v)
	  { // v?????
		Vertex m = v.right;
		v.right = parent;
		parent.left = m;
	  }
	  else
	  {
		Vertex m = v.left;
		v.left = parent;
		parent.right = m;
	  }
	  update(parent);
	  update(v);
	  v.parent = grandparent;
	  if (grandparent != null)
	  {
		if (grandparent.left == parent)
		{
		  grandparent.left = v;
		}
		else
		{
		  grandparent.right = v;
		}
	  }
	}

	public static void big_rotation(Vertex v)
	{ //????
	  if (v.parent.left == v && v.parent.parent.left == v.parent)
	  {
		// Zig-zig
		small_rotation(v.parent);
		small_rotation(v);
	  }
	  else if (v.parent.right == v && v.parent.parent.right == v.parent)
	  {
		// Zig-zig
		small_rotation(v.parent);
		small_rotation(v);
	  }
	  else
	  {
		// Zig-zag
		small_rotation(v);
		small_rotation(v);
	  }
	}

	// Makes splay of the given vertex and makes
	// it the new root.
	public static void splay(ref Vertex root, Vertex v)
	{
	  if (v == null)
	  {
		return;
	  }
	  while (v.parent != null)
	  {
		if (v.parent.parent == null)
		{ // v????????,??????????
		  small_rotation(v);
		  break;
		}
		big_rotation(v); // g-p-v??,??????
	  }
	  root = v;
	}

	// Searches for the given key in the tree with the given root
	// and calls splay for the deepest visited node after that.
	// If found, returns a polonger to the node with the given key.
	// Otherwise, returns a polonger to the node with the smallest
	// bigger key (next value in the order).
	// If the key is bigger than all keys in the tree,
	// returns NULL.
	public static Vertex find(ref Vertex root, long key)
	{
	  Vertex v = root;
	  Vertex last = root;
	  Vertex next = null;
	  while (v != null)
	  { // v???????
		if (v.key >= key  && (next == null || v.key < next.key))
		{ //???next????????ley???
		  next = v; //???key????????
		}
		last = v;
		if (v.key == key)
		{ //??key,????
		  break;
		}
		if (v.key < key)
		{ // v.key<key,?v??????
		  v = v.right;
		}
		else
		{ // key>v.key,?v??????
		  v = v.left;
		}
	  }
	  splay(ref root, last); //??????????????
	  return next;
	}

	public static void split(Vertex root, long key, ref Vertex left, ref Vertex right)
	{
	  right = find(ref root, key);
	  splay(ref root, right); //???????????
	  if (right == null)
	  {
		left = root;
		return;
	  }
	  left = right.left; //???????????
	  right.left = null;
	  if (left != null)
	  {
		left.parent = null; //?????
	  }
	  update(left); //???????
	  update(right);
	}

	public static Vertex merge(Vertex left, Vertex right)
	{
	  if (left == null)
	  {
		return right;
	  }
	  if (right == null)
	  {
		return left;
	  }
	  Vertex min_right = right;
	  while (min_right.left != null)
	  {
		min_right = min_right.left; //??right??????
	  }
	  splay(ref right, min_right); //???key????????
	  right.left = left;
	  update(right);
	  return right;
	}

	// Code that uses splay tree to solve the problem

	public static Vertex root = null;

	public static void insert(long x)
	{
	  Vertex left = null;
	  Vertex right = null;
	  Vertex new_vertex = null;
	  split(root, x, ref left, ref right);
	  if (right == null || right.key != x)
	  {
		new_vertex = new Vertex(x, x, null, null, null); //???x,???????x
	  }
	  root = merge(merge(left, new_vertex), right);
	}

	public static bool find(long x)
	{
	  // Implement find yourself
	  Vertex ans = find(ref root, x);
	  if (ans != null && ans.key == x)
	  {
		return true;
	  }
	  else
	  {
		return false;
	  }
	}
	public static void erase(long x)
	{
	  // Implement erase yourself
	  if (root == null || find(x) == false) //????????????,?????
	  {
		return;
	  }
	  Vertex w = root; //?find?,????????????
	  if (root.left == null)
	  { //?????,????
		root = root.right;
		if (root != null)
		{
		  root.parent = null;
		}

	  }
	  else if (root.right == null)
	  { //?????,?????
		root = root.left;
		if (root != null)
		{
		  root.parent = null;
		}
	  }
	  else
	  { //????????
		Vertex lt = root.left;
		lt.parent = null;
		root.left = null; //????????
		root = root.right;
		root.parent = null; //??????
		bool temp = find(w.key); //???????,???(?????)??
		// ??,?????????????,?(??????)??????,??
		root.left = lt; //?????????????
		lt.parent = root;
	  }
	  w = null; //????
	  if (root != null) //????,????
	  {
		update(root);
	  }
	}
	public static long sum(long from, long to)
	{
	  Vertex left = null;
	  Vertex middle = null;
	  Vertex right = null;
	  split(root, from, ref left, ref middle);
	  split(middle, to + 1, ref middle, ref right);
	  long ans = 0;
	  // Complete the implementation of sum
	  if (middle != null) //??????????
	  {
		ans = middle.sum;
	  }
	  middle = merge(middle, right);
	  root = merge(left, middle);
	  return ans;
	}

	public static readonly long MODULO = 1000000001;

	static int Main()
	{
	  long n = 0;
	  string tempVar = Console.ReadLine();
	  if (tempVar != null)
	  {
		  n = long.Parse(tempVar);
	  }
	  long last_sum_result = 0;
	  for (long i = 0; i < n; i++)
	  {
		string buffer = new string(new char[10]);
		string tempVar2 = Console.ReadLine();
		if (tempVar2 != null)
		{
			buffer = tempVar2;
		}
		char type = buffer[0];
        string number = buffer.Trim(type);
        number = number.Trim();
        long x = 0;
        long l = 0 ;
        long r = 0;
        if (type != 's')
        {
            x = long.Parse(number);
        }
        
        else
        {
            var splited = number.Split();
            l = long.Parse(splited[0]);
            r = long.Parse(splited[1]);
        }
        
		switch (type)
		{
		case '+':
		{
		  
		  insert((x + last_sum_result) % MODULO);
		}
		break;
		case '-':
		{
		  
		  erase((x + last_sum_result) % MODULO);
		}
		break;
		case '?':
		{
		  
		  Console.Write(find((x + last_sum_result) % MODULO) ? "Found\n" : "Not found\n");
		}
		break;
		case 's':
		{
		  
		  long res = sum((l + last_sum_result) % MODULO, (r + last_sum_result) % MODULO);
		  Console.Write("{0:D}\n", res);
		  last_sum_result = (long)(res % MODULO);
		}
	break;
		}
	  }
	  return 0;
	}
}


