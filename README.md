# RefToken
Framework for capturing the value of an object using a string path
- Currently you can only get values from variables and lists (using index)

## How to use
  - High traffic
  ```C#
  var refToken = new RefToken.RefToken(//string path);
  var found =  refToken.Select<string>(targetObject, out string result);
  if(found)
  {
    Console.WriteLine(result);
  }
  ```‍‍‍‍
  
## Access the value using the string path
```C#

```
