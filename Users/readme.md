# User CRUD


## Create a User data

Create a new user data in the sql database.

    POST /api/CreateUser

### Parameters
| Name  | Type | Description |
| ------------- | ------------- | ------------- |
| `name`  | `string`  |  The user's name.|
| `password`  | `string`  |  The user's password.|

### Example for creating a user

    {
        "name": "Varsik",
        "password": "password"
    }
### Response
    user is created, the id is xxx
    
## Get a User data

Get a user data from the sql database.

    GET /api/GetUserById/:userid

### Response

    {
      "id":1,
      "name": "Varsik",
      "password": "password"
    }
    
## Get a All Users 

Get a users list from the sql database.
    
    GET /api/GetAllUser
    
### Response

    [
        {
            "id": 1,
            "name": "Varsik",
            "password": "password"
        },
        ...
    ]

## Update a User data

Update a existing user data in the sql database.

    PUT /api/UpdateUser/:userid
    
## Delete a User data
Delete a user data in the database.

    DELETE /api/DeleteUser/:userid
    