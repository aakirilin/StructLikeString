# StructLikeString
The string is similar to the structure.

Everyone knows that a string in C# is not a significant type and is placed in a heap, and its length is practically unlimited. However, often, especially when working with databases, the string length is reasonably limited. Therefore, I would like to place it on the stack. I present to you the implementation of the string that is stored on the stack.
