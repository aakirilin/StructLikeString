# StructLikeString
The string is similar to the structure.

Everyone knows that a string in C# is not a significant type and is placed in a heap, and its length is practically unlimited. However, often, especially when working with databases, the string length is reasonably limited. Therefore, I would like to place it on the stack. I present to you the implementation of the string that is stored on the stack.

Example:
```C#
var s1 = new CString10();
var s2 = new CString10();

s1.SetString("Hello, World!");
s2.SetString("Привет мир!");

Console.WriteLine(s1.ToString()); // Hello, Wor
Console.WriteLine(s2.ToString()); // Привет мир

s1 = s2;

Console.WriteLine(s1.ToString()); // Привет мир
Console.WriteLine(s2.ToString()); // Привет мир

s1[0] = 'g';

Console.WriteLine(s1.ToString()); // gривет мир
Console.WriteLine(s2.ToString()); // Привет мир

s2[0] = 'h';

Console.WriteLine(s1.ToString()); // gривет мир
Console.WriteLine(s2.ToString()); // hривет мир
```
