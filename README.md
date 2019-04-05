# Binodata.EF.Component

### ����
* Biniodata  �@�θ�Ʈw�ާ@�禡�w

### �s�W��ƽd��


```<C#>
IUnitofWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<Context>();
IGenericRepository<Customer> repo = unitOfWork.GetGenericRepository<Customer>();
repo.Add(new Customer(){Name = "B", BirthDay = "1966/01/05"});
unitOfWork.Save();

unitOfWork.Dispose();
```


### ��s��ƽd��


```<C#>

var customer = SelectFromDB(x => x.Name == "B");
customer.Name = "C";

IUnitofWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<Context>();
IGenericRepository<Customer> repo = unitOfWork.GetGenericRepository<Customer>();
repo.Edit(customer);
unitOfWork.Save();

unitOfWork.Dispose();
```



### �d�߸�ƽd��


```<C#>



IUnitofWork unitOfWork = EFUnitOfWorkFactory.GetUnitOfWork<Context>();
IGenericRepository<Customer> repo = unitOfWork.GetGenericRepository<Customer>();
repo.QueryByCondition(x => x.Name == "B");
unitOfWork.Dispose();
```
