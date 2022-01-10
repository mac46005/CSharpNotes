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