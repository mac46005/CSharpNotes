# Delegate Notes  

## Creating a delegate  
```
public delegate bool RequiredValidDel(string fieldVal);
```
- A delegate **can have a return type or no return**
- A delegate **can have any number parameters or none**
- A delegate can be made within a class or on the namespace itself
- A multiple delegate objects can be appended together to make a super delegate

## Using a delegate  
To use the delegate first create a delegate object  
```
private static RequiredValidDel _requiredValidDel = null;

```

Then provide a method that uses the same exact signature  
```
_requiredValidDel = new RequiredValidDel(RequiredFieldValid);

private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            return false;
        }
```


Complete Example  
```
public delegate bool RequiredValidDel(string fieldVal);

private static RequiredValidDel _requiredValidDel = null;

private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            return false;
        }
```



# Covariance And Contravariance

## Covariance  
More Derived


```
Public class BaseClass
{
    //class code
}

Public class DerviedClass1 : BaseClass
{
    //class code
}

public class DerivedClass2 : BaseClass
{
    //class code
}

delegate BaseClass BaseClassFactoryDel();

public static BaseClassFactory{
    public static DerivedClass1 ReturnDerivedClass1(){
        return new DerivcedClass1();
    }
    public static DerivedClass2 ReturnDerivedClass2(){
        return new DerivedClass2();
    }
}

static void Main(){
    BaseClassFactoryDel baseClassFactoryDel = BaseClassFactory.ReturnDerivedClass1;
    BaseClass derivedClass1 = baseClassFactoryDel(); // Returns a DerivedClass1

    baseClassFactoryDel = BaseClassFactory.ReturnDerviedClass2;
    BaseClass derivedClass2 = baseClassFactoryDel.ReturnDerivedClass2(); // Returns a Derived class 2
}


```

Even though the return type of 'MyMethod' method is more derive than the MyDelegate 
delagates return type, an object of type MyDelegate, can reference the MyMethod method.




## Contravariance  
Less derived


```
public class BaseClass{
    // class code
}

public class DerivedClass1 : BaseClass{
    // class code
}

public class DerivedClass2 : BaseClass{
    // class code
}

delegate void MyDelegate1(DerivedClass1 derivedClass1);
delegate void MyDelegate2(DerivedClass2 derivedClass2);

public static void Method(BaseClass obj){
    // method code
}

static void Main(){
    MyDelegate1 myDelegate1 = MyMethod;
    MyDelegate2 myDelegate2 = MyMethod;
}
```  

Even though the parameter type of MyMethod is less derived than the parameter type of the MyDelegate1 and MyDelegate2 delegates an object of type MyDelegate1 and MyDelegate2 can reference the MyMethod method with parameter of BaseClass



# Func Action Predicate  

## Func  
Is a delegate can represent an anaymous method that takes in any number of parameters up to a total of 16 with a return type  
```
Func<in T,in T,...,out T> myFunc;

myFunc = delegate(ar1,...,argNth) => {
    //Do functions with args
}

myFunc = (arg1,...,argNth) => {
    //Do function with args
}

TType = myFunc(ar1,...,arg16);
```

## Action  
Is a delegate type that can produces anaynomous methods or be referenced. This delegate can have up to 16 parameter types and no return type   
```
Action<T1,...,T16> myAction;

myAction = delegate(arg1,...,arg16) => {
    // Do Action
}

myAction = (arg1,...,arg16) => {
    //Do Action
}

myAction()
```

## Predicate  
Is used to 