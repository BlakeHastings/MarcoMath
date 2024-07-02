# MarcoMath

This is a library for creating, manipulating, and sampling custom distributions. This library is by no means optimized or likely useful outside the project it was created for. 

# How it works

Distributions are C# classes that wrap changes to the X value when sampled acting as a memoization pattern. This means the distributions do not actually exist or cost anything further than memory until a sample is made and the stack of distribution classes are evaluated. 
