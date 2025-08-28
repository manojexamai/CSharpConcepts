// See https://aka.ms/new-console-template for more information
using Demo_Partial;


Demo obj = new Demo();
obj.Id = 1;
obj.Name = "test";

// Object Initializer example
Demo obj2 = new Demo() {  Id = 1, Name = "test" };
obj2.Display();


// NOTE: Run this by EXCLUDE/INCLUDE File
MyPartialMethodDemo demo = new MyPartialMethodDemo();
demo.DoSomething();

