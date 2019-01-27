# MyGroceryCart

UML: Grocery Item
__________________________________________________________
|   GroceryItem                                           |
|_________________________________________________________|
| + Name : string {get} (readonly)                        |
| + Price: decimal {get; private set}                     |
| + Quantity: int {get, private set}                      |
|_________________________________________________________|
| + GroceryItem (string name, decimal price, int quantity)|
| + GroceryItem (string name, decimal price)              |
|_________________________________________________________|
| + AddCoupon(int couponPercentage)                       |
|_________________________________________________________|

UML: GroceryCart
___________________________________________________________
|   GroceryCart                                            |
|__________________________________________________________|
| + TotalPrice : decimal {get; private set}                |
| + TotalNumberOfItems: int {get; private set}             |
| - groceryItems : List<GroceryItem>                       |
|__________________________________________________________|
| + AddItemToCart(name) : bool                             |
| + RemoveItemFromCart(string name) : bool                 |
| + GetTotal() : decimal                                   |
|__________________________________________________________|