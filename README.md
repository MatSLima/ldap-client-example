# ldap-client
LDAP client used to add and authenticate a user with apache active directory.

## Docker
Run the following command:
```
docker run -it --rm -p 389:10389 matslima/rgs-ldap
```

## Running authentication
Run the following command
```
dotnet run --project LDAPClient
```