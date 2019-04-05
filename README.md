# Binodata.EF.Component

### 說明
* Biniodata  共用資料庫操作函式庫

### 新增資料範例


```<C#>
IUnitofWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<Context>();
IGenericRepository<Customer> repo = unitOfWork.GetGenericRepository<Customer>();
repo.Add(new Customer(){Name = "B", BirthDay = "1966/01/05"});
unitOfWork.Save();

unitOfWork.Dispose();
```


### 更新資料範例


```<C#>

var customer = SelectFromDB(x => x.Name == "B");
customer.Name = "C";

IUnitofWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<Context>();
IGenericRepository<Customer> repo = unitOfWork.GetGenericRepository<Customer>();
repo.Edit(customer);
unitOfWork.Save();

unitOfWork.Dispose();
```



### 查詢資料範例


```<C#>



IUnitofWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<Context>();
IGenericRepository<Customer> repo = unitOfWork.GetGenericRepository<Customer>();
repo.QueryByCondition(x => x.Name == "B");
unitOfWork.Dispose();
```
