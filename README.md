# ShopBridgeEcommerce
This is assessment Test for Shopping Bridge: We have to create the web Application with ASP.NET Core and EF Core for Data base connectivity. we have used the SQl server for data base management.
We have implement the Generic repository to perform the CRUD Application. To Log the information to data base we have used the serilog with msSql sink. We have also implement
the versioning in Api so that we can have multiple version if we required in future. We have also implement the IpRateLimiting so that client can able to access the Api 2 timens in 10 second.

# Architecture:
we have implemented the onion Architcture to develo the application, we have follow this architecture so that we can able to implement the microservice easily. Please find the below image to understand the architecture of the application:
![image](https://user-images.githubusercontent.com/48491702/215265166-43196b39-a8a8-419b-8180-9598bb022be1.png)

# Automapper
We have also implement the Automapper for creating the DTO for converting the entity to model class and model class to entity.

# IpRateLimiting

W have also implement the Rate Limiting and Api throtling, So that User/Client can able to access the Api withing the specified time interval, For Example we have 10 second rate limiting means from one IP if we have access the Api (2 times) then from next Api call will have give Limit Exception:
