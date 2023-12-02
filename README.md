# Assessment
The Web API is built using .NET 8.0 and Visual Studio 2022. The app uses Entity Framework in Memory persistence which is available in .NET 8.0 framework. The solution has two projects. A Web API project and a Unit Test project for the Web API. The unit test project is built using XUnit and FakeItEasy Nuget package for mock frameworks. 
To run the project, open the solution in Visual Studio 2022. Run the application in http. The solution uses Swagger to test the endpoints. 
The Web API implements the below endpoints.
ItemsController: CreateItems - Creates an item with title and price fields. Input title and Price.
                GetItems  - Retrieves all items 
                GetItemById - Retrieves an in item based on ItemId. Input ItemId.
                UpdateItem - Updates the details of an item based on ItemId. Input ItemId, Title, Price
                DeleteItem - Deletes an item based on ItemId. Input ItemId

ShoppingCartController: AddItemsToCart - Adds items to Cart. Takes input ItemId and Quantity.
                        GetCartContents - lists the contents of the cart.
                        UpdateCartItemQuantity - updates the quantity of an item in the cart. Input itemId and quantity.
