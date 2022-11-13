# Wishlist API application
</br>
> API operations for adding, deleting, updating and searching wishes
</br>
> Using C#, .NET 6, PostgreSQL, Entity Framework with code first approach
</br>
> Unit testing done using xUnit, Fluent Assertions and in-memory testing where necessary

## API Operations

### Wish Operations

### Example Wish object json

```
{
  "name": "Wish name"
}
```

### HTTP Put for adding a wish
> /wishlist/add

### HTTP Delete for deleting a wish
> /wishlist/delete/id (id = integer)

### HTTP Put for updating a wish
> /wishlist/update/id (id = integer)

### HTTP Get for getting wish by id
> /wishlist/wish/id (id = integer)

###HTTP Get for getting all wishes 
> /wishlist/wishes
</br>

### User Operations

### Example User json

```
{
  "users": [
    {
      "type": "user",
      "name": "Username 1",
      "email": "email1@site.com"
    },
    {
      "type": "user",
      "name": "Username 2",
      "email": "email2@site.com"
    },
    {
      "type": "user",
      "name": "Username 3",
      "email": "email3@site.com"
    }
  ]
}
```

> type: string

> name: string

> email: string

### HTTP Post for getting a string of all the usernames seperated by a comma
> /users
</br>
> Example json would return "Username 1, Username 2, Username 3"



