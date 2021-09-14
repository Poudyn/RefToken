# RefToken
Framework for capturing the value of an object using a string path
- Currently you can only get values from variables and lists (using index)

## How to use
  - High traffic
  ```C#
  var refToken = new RefToken.RefToken("string path");
  var found =  refToken.Select<string>(targetObject, out string result);
  if(found)
  {
    Console.WriteLine(result);
  }
  ```
  - Low traffic
  ```C#
  var found = RefToken.Select<string>(targetObject,"string path",out string result);
  if(found)
  {
    Console.WriteLine(result);
  }
  ```
  
## Access the value using the string path
```C#
class Persone
{
  public string Name {set;get;}
}
class Buyer
{
  public Persone persone {set;get;}
}
var buyer = new Buyer { Persone = new Persone {Name = "Poudyn"} };
var found = RefToken.Select<string>(buyer,"Persone.Name",out string result);
if(found)
{
  Console.WriteLine(result);
}
```
Contact with me : [Telegram](https://t.me/ThePoudyn)

News : [Telegram Channel](https://t.me/IPouDyn)
