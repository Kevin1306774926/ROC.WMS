﻿

// ------------------------------------------------------------------------------------------------
// This code was generated by EntityFramework Reverse POCO Generator (http://www.reversepoco.com/).
// Created by Simon Hughes (https://about.me/simon.hughes).
// 
// Do not make changes directly to this file - edit the template instead.
// 
// The following connection settings were used to generate this file:
//     Configuration file:     "ROC.Modles\App.config"
//     Connection String Name: "RocContext"
//     Connection String:      "Data Source=(local);Initial Catalog=roc_wms;Integrated Security=True;Application Name=MyApp"
// ------------------------------------------------------------------------------------------------
// Database Edition       : Express Edition
// Database Engine Edition: Express

// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

namespace ROC.Modles
{
    using System.Linq;

    #region Unit of work

    public interface IRocContext : System.IDisposable
    {
        System.Data.Entity.DbSet<ActionInfo> ActionInfoes { get; set; } // ActionInfo
        System.Data.Entity.DbSet<Menu> Menus { get; set; } // Menu
        System.Data.Entity.DbSet<MenuClass> MenuClasses { get; set; } // MenuClass
        System.Data.Entity.DbSet<Role> Roles { get; set; } // Role
        System.Data.Entity.DbSet<RoleActionInfo> RoleActionInfoes { get; set; } // RoleActionInfo
        System.Data.Entity.DbSet<User> Users { get; set; } // User
        System.Data.Entity.DbSet<UserRole> UserRoles { get; set; } // UserRole

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
        
        // Stored Procedures
        int UploadRolePermission(System.Guid? roleId);
        // UploadRolePermissionAsync cannot be created due to having out parameters, or is relying on the procedure result (int)

    }

    #endregion

    #region Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class RocContext : System.Data.Entity.DbContext, IRocContext
    {
        public System.Data.Entity.DbSet<ActionInfo> ActionInfoes { get; set; } // ActionInfo
        public System.Data.Entity.DbSet<Menu> Menus { get; set; } // Menu
        public System.Data.Entity.DbSet<MenuClass> MenuClasses { get; set; } // MenuClass
        public System.Data.Entity.DbSet<Role> Roles { get; set; } // Role
        public System.Data.Entity.DbSet<RoleActionInfo> RoleActionInfoes { get; set; } // RoleActionInfo
        public System.Data.Entity.DbSet<User> Users { get; set; } // User
        public System.Data.Entity.DbSet<UserRole> UserRoles { get; set; } // UserRole

        static RocContext()
        {
            System.Data.Entity.Database.SetInitializer<RocContext>(null);
        }

        public RocContext()
            : base("Name=RocContext")
        {
        }

        public RocContext(string connectionString)
            : base(connectionString)
        {
        }

        public RocContext(string connectionString, System.Data.Entity.Infrastructure.DbCompiledModel model)
            : base(connectionString, model)
        {
        }

        public RocContext(System.Data.Common.DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
        }

        public RocContext(System.Data.Common.DbConnection existingConnection, System.Data.Entity.Infrastructure.DbCompiledModel model, bool contextOwnsConnection)
            : base(existingConnection, model, contextOwnsConnection)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public bool IsSqlParameterNull(System.Data.SqlClient.SqlParameter param)
        {
            var sqlValue = param.SqlValue;
            var nullableValue = sqlValue as System.Data.SqlTypes.INullable;
            if (nullableValue != null)
                return nullableValue.IsNull;
            return (sqlValue == null || sqlValue == System.DBNull.Value);
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ActionInfoConfiguration());
            modelBuilder.Configurations.Add(new MenuConfiguration());
            modelBuilder.Configurations.Add(new MenuClassConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new RoleActionInfoConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
        }

        public static System.Data.Entity.DbModelBuilder CreateModel(System.Data.Entity.DbModelBuilder modelBuilder, string schema)
        {
            modelBuilder.Configurations.Add(new ActionInfoConfiguration(schema));
            modelBuilder.Configurations.Add(new MenuConfiguration(schema));
            modelBuilder.Configurations.Add(new MenuClassConfiguration(schema));
            modelBuilder.Configurations.Add(new RoleConfiguration(schema));
            modelBuilder.Configurations.Add(new RoleActionInfoConfiguration(schema));
            modelBuilder.Configurations.Add(new UserConfiguration(schema));
            modelBuilder.Configurations.Add(new UserRoleConfiguration(schema));
            return modelBuilder;
        }
        
        // Stored Procedures
        public int UploadRolePermission(System.Guid? roleId)
        {
            var roleIdParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@RoleId", SqlDbType = System.Data.SqlDbType.UniqueIdentifier, Direction = System.Data.ParameterDirection.Input, Value = roleId.GetValueOrDefault() };
            if (!roleId.HasValue)
                roleIdParam.Value = System.DBNull.Value;

            var procResultParam = new System.Data.SqlClient.SqlParameter { ParameterName = "@procResult", SqlDbType = System.Data.SqlDbType.Int, Direction = System.Data.ParameterDirection.Output };
 
            Database.ExecuteSqlCommand("EXEC @procResult = [dbo].[UploadRolePermission] @RoleId", roleIdParam, procResultParam);
 
            return (int) procResultParam.Value;
        }

    }
    #endregion

    #region Fake Database context

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class FakeRocContext : IRocContext
    {
        public System.Data.Entity.DbSet<ActionInfo> ActionInfoes { get; set; }
        public System.Data.Entity.DbSet<Menu> Menus { get; set; }
        public System.Data.Entity.DbSet<MenuClass> MenuClasses { get; set; }
        public System.Data.Entity.DbSet<Role> Roles { get; set; }
        public System.Data.Entity.DbSet<RoleActionInfo> RoleActionInfoes { get; set; }
        public System.Data.Entity.DbSet<User> Users { get; set; }
        public System.Data.Entity.DbSet<UserRole> UserRoles { get; set; }

        public FakeRocContext()
        {
            ActionInfoes = new FakeDbSet<ActionInfo>("Id");
            Menus = new FakeDbSet<Menu>("Controller");
            MenuClasses = new FakeDbSet<MenuClass>("Id");
            Roles = new FakeDbSet<Role>("Id");
            RoleActionInfoes = new FakeDbSet<RoleActionInfo>("Id");
            Users = new FakeDbSet<User>("Id");
            UserRoles = new FakeDbSet<UserRole>("Id");
        }

        public int SaveChangesCount { get; private set; }
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1);
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
        }
        
        // Stored Procedures
        public int UploadRolePermission(System.Guid? roleId)
        {
 
            return 0;
        }

    }

    // ************************************************************************
    // Fake DbSet
    // Implementing Find:
    //      The Find method is difficult to implement in a generic fashion. If
    //      you need to test code that makes use of the Find method it is
    //      easiest to create a test DbSet for each of the entity types that
    //      need to support find. You can then write logic to find that
    //      particular type of entity, as shown below:
    //      public class FakeBlogDbSet : FakeDbSet<Blog>
    //      {
    //          public override Blog Find(params object[] keyValues)
    //          {
    //              var id = (int) keyValues.Single();
    //              return this.SingleOrDefault(b => b.BlogId == id);
    //          }
    //      }
    //      Read more about it here: https://msdn.microsoft.com/en-us/data/dn314431.aspx
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class FakeDbSet<TEntity> : System.Data.Entity.DbSet<TEntity>, IQueryable, System.Collections.Generic.IEnumerable<TEntity>, System.Data.Entity.Infrastructure.IDbAsyncEnumerable<TEntity> where TEntity : class
    {
        private readonly System.Reflection.PropertyInfo[] _primaryKeys;
        private readonly System.Collections.ObjectModel.ObservableCollection<TEntity> _data;
        private readonly IQueryable _query;

        public FakeDbSet()
        {
            _data = new System.Collections.ObjectModel.ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public FakeDbSet(params string[] primaryKeys)
        {
            _primaryKeys = typeof(TEntity).GetProperties().Where(x => primaryKeys.Contains(x.Name)).ToArray();
            _data = new System.Collections.ObjectModel.ObservableCollection<TEntity>();
            _query = _data.AsQueryable();
        }

        public override TEntity Find(params object[] keyValues)
        {
            if (_primaryKeys == null)
                throw new System.ArgumentException("No primary keys defined");
            if (keyValues.Length != _primaryKeys.Length)
                throw new System.ArgumentException("Incorrect number of keys passed to Find method");

            var keyQuery = this.AsQueryable();
            keyQuery = keyValues
                .Select((t, i) => i)
                .Aggregate(keyQuery,
                    (current, x) =>
                        current.Where(entity => _primaryKeys[x].GetValue(entity, null).Equals(keyValues[x])));

            return keyQuery.SingleOrDefault();
        }

        public override System.Threading.Tasks.Task<TEntity> FindAsync(System.Threading.CancellationToken cancellationToken, params object[] keyValues)
        {
            return System.Threading.Tasks.Task<TEntity>.Factory.StartNew(() => Find(keyValues), cancellationToken);
        }

        public override System.Threading.Tasks.Task<TEntity> FindAsync(params object[] keyValues)
        {
            return System.Threading.Tasks.Task<TEntity>.Factory.StartNew(() => Find(keyValues));
        }

        public override System.Collections.Generic.IEnumerable<TEntity> AddRange(System.Collections.Generic.IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new System.ArgumentNullException("entities");
            var items = entities.ToList();
            foreach (var entity in items)
            {
                _data.Add(entity);
            }
            return items;
        }

        public override TEntity Add(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override TEntity Remove(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Remove(item);
            return item;
        }

        public override TEntity Attach(TEntity item)
        {
            if (item == null) throw new System.ArgumentNullException("item");
            _data.Add(item);
            return item;
        }

        public override TEntity Create()
        {
            return System.Activator.CreateInstance<TEntity>();
        }

        public override TDerivedEntity Create<TDerivedEntity>()
        {
            return System.Activator.CreateInstance<TDerivedEntity>();
        }

        public override System.Collections.ObjectModel.ObservableCollection<TEntity> Local
        {
            get { return _data; }
        }

        System.Type IQueryable.ElementType
        {
            get { return _query.ElementType; }
        }

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _query.Expression; }
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<TEntity>(_query.Provider); }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Collections.Generic.IEnumerator<TEntity> System.Collections.Generic.IEnumerable<TEntity>.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        System.Data.Entity.Infrastructure.IDbAsyncEnumerator<TEntity> System.Data.Entity.Infrastructure.IDbAsyncEnumerable<TEntity>.GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<TEntity>(_data.GetEnumerator());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class FakeDbAsyncQueryProvider<TEntity> : System.Data.Entity.Infrastructure.IDbAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public FakeDbAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
        {
            return new FakeDbAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            return new FakeDbAsyncEnumerable<TElement>(expression);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public System.Threading.Tasks.Task<object> ExecuteAsync(System.Linq.Expressions.Expression expression, System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute(expression));
        }

        public System.Threading.Tasks.Task<TResult> ExecuteAsync<TResult>(System.Linq.Expressions.Expression expression, System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(Execute<TResult>(expression));
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class FakeDbAsyncEnumerable<T> : EnumerableQuery<T>, System.Data.Entity.Infrastructure.IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public FakeDbAsyncEnumerable(System.Collections.Generic.IEnumerable<T> enumerable)
            : base(enumerable)
        { }

        public FakeDbAsyncEnumerable(System.Linq.Expressions.Expression expression)
            : base(expression)
        { }

        public System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new FakeDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        System.Data.Entity.Infrastructure.IDbAsyncEnumerator System.Data.Entity.Infrastructure.IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new FakeDbAsyncQueryProvider<T>(this); }
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class FakeDbAsyncEnumerator<T> : System.Data.Entity.Infrastructure.IDbAsyncEnumerator<T>
    {
        private readonly System.Collections.Generic.IEnumerator<T> _inner;

        public FakeDbAsyncEnumerator(System.Collections.Generic.IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public void Dispose()
        {
            _inner.Dispose();
        }

        public System.Threading.Tasks.Task<bool> MoveNextAsync(System.Threading.CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(_inner.MoveNext());
        }

        public T Current
        {
            get { return _inner.Current; }
        }

        object System.Data.Entity.Infrastructure.IDbAsyncEnumerator.Current
        {
            get { return Current; }
        }
    }

    #endregion

    #region POCO classes

    // ActionInfo
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class ActionInfo
    {
        public System.Guid Id { get; set; } // Id (Primary key)
        public string Action { get; set; } // Action (length: 50)
        public string ActionName { get; set; } // ActionName (length: 50)
        public string Controller { get; set; } // Controller (length: 50)
        public System.DateTime OpTime { get; set; } // OpTime
        public string Description { get; set; } // Description (length: 200)
        public bool IsUsed { get; set; } // IsUsed
        public string ControllerName { get; set; } // ControllerName (length: 50)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<RoleActionInfo> RoleActionInfoes { get; set; } // RoleActionInfo.FK_RoleActionInfo_ActionInfo

        // Foreign keys
        public virtual Menu Menu { get; set; } // FK_ActionInfo_Menu

        public ActionInfo()
        {
            Id = System.Guid.NewGuid();
            OpTime = System.DateTime.Now;
            IsUsed = true;
            RoleActionInfoes = new System.Collections.Generic.List<RoleActionInfo>();
        }
    }

    // Menu
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class Menu
    {
        public string Code { get; set; } // Code (length: 50)
        public string Name { get; set; } // Name (length: 50)
        public string Controller { get; set; } // Controller (Primary key) (length: 50)
        public string Description { get; set; } // Description (length: 100)
        public System.DateTime OpTime { get; set; } // OpTime
        public int? Class { get; set; } // Class
        public string Url { get; set; } // Url (length: 100)
        public bool? IsUsed { get; set; } // IsUsed

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<ActionInfo> ActionInfoes { get; set; } // ActionInfo.FK_ActionInfo_Menu

        // Foreign keys
        public virtual MenuClass MenuClass { get; set; } // FK_Menu_MenuClass

        public Menu()
        {
            IsUsed = true;
            ActionInfoes = new System.Collections.Generic.List<ActionInfo>();
        }
    }

    // MenuClass
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class MenuClass
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 50)
        public int? ParentId { get; set; } // ParentId

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Menu> Menus { get; set; } // Menu.FK_Menu_MenuClass

        public MenuClass()
        {
            Menus = new System.Collections.Generic.List<Menu>();
        }
    }

    // Role
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class Role
    {
        public System.Guid Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 50)
        public string Description { get; set; } // Description (length: 100)
        public System.DateTime? OpTime { get; set; } // OpTime
        public string Opration { get; set; } // Opration (length: 50)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<RoleActionInfo> RoleActionInfoes { get; set; } // RoleActionInfo.FK_RoleActionInfo_Role
        public virtual System.Collections.Generic.ICollection<UserRole> UserRoles { get; set; } // UserRole.FK_UserRole_Role

        public Role()
        {
            Id = System.Guid.NewGuid();
            RoleActionInfoes = new System.Collections.Generic.List<RoleActionInfo>();
            UserRoles = new System.Collections.Generic.List<UserRole>();
        }
    }

    // RoleActionInfo
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class RoleActionInfo
    {
        public int Id { get; set; } // Id (Primary key)
        public System.Guid RoleId { get; set; } // RoleId
        public System.Guid ActionId { get; set; } // ActionId
        public bool IsUsed { get; set; } // IsUsed

        // Foreign keys
        public virtual ActionInfo ActionInfo { get; set; } // FK_RoleActionInfo_ActionInfo
        public virtual Role Role { get; set; } // FK_RoleActionInfo_Role

        public RoleActionInfo()
        {
            IsUsed = true;
        }
    }

    // User
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class User
    {
        public System.Guid Id { get; set; } // Id (Primary key)
        public string Code { get; set; } // Code (length: 50)
        public string Name { get; set; } // Name (length: 50)
        public string Password { get; set; } // Password (length: 50)
        public bool IsStop { get; set; } // IsStop
        public string Operator { get; set; } // Operator (length: 50)
        public System.DateTime? OpTime { get; set; } // OpTime

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<UserRole> UserRoles { get; set; } // UserRole.FK_UserRole_User

        public User()
        {
            Id = System.Guid.NewGuid();
            IsStop = true;
            UserRoles = new System.Collections.Generic.List<UserRole>();
        }
    }

    // UserRole
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class UserRole
    {
        public int Id { get; set; } // Id (Primary key)
        public System.Guid UserId { get; set; } // UserId
        public System.Guid RoleId { get; set; } // RoleId

        // Foreign keys
        public virtual Role Role { get; set; } // FK_UserRole_Role
        public virtual User User { get; set; } // FK_UserRole_User
    }

    #endregion

    #region POCO Configuration

    // ActionInfo
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class ActionInfoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<ActionInfo>
    {
        public ActionInfoConfiguration()
            : this("dbo")
        {
        }

        public ActionInfoConfiguration(string schema)
        {
            ToTable(schema + ".ActionInfo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Action).HasColumnName(@"Action").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.ActionName).HasColumnName(@"ActionName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Controller).HasColumnName(@"Controller").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.OpTime).HasColumnName(@"OpTime").IsRequired().HasColumnType("datetime");
            Property(x => x.Description).HasColumnName(@"Description").IsOptional().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.IsUsed).HasColumnName(@"IsUsed").IsRequired().HasColumnType("bit");
            Property(x => x.ControllerName).HasColumnName(@"ControllerName").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);

            // Foreign keys
            HasOptional(a => a.Menu).WithMany(b => b.ActionInfoes).HasForeignKey(c => c.Controller); // FK_ActionInfo_Menu
        }
    }

    // Menu
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class MenuConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration()
            : this("dbo")
        {
        }

        public MenuConfiguration(string schema)
        {
            ToTable(schema + ".Menu");
            HasKey(x => x.Controller);

            Property(x => x.Code).HasColumnName(@"Code").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Controller).HasColumnName(@"Controller").IsRequired().HasColumnType("nvarchar").HasMaxLength(50).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Description).HasColumnName(@"Description").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.OpTime).HasColumnName(@"OpTime").IsRequired().HasColumnType("datetime");
            Property(x => x.Class).HasColumnName(@"Class").IsOptional().HasColumnType("int");
            Property(x => x.Url).HasColumnName(@"Url").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.IsUsed).HasColumnName(@"IsUsed").IsOptional().HasColumnType("bit");

            // Foreign keys
            HasOptional(a => a.MenuClass).WithMany(b => b.Menus).HasForeignKey(c => c.Class).WillCascadeOnDelete(false); // FK_Menu_MenuClass
        }
    }

    // MenuClass
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class MenuClassConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MenuClass>
    {
        public MenuClassConfiguration()
            : this("dbo")
        {
        }

        public MenuClassConfiguration(string schema)
        {
            ToTable(schema + ".MenuClass");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.ParentId).HasColumnName(@"ParentId").IsOptional().HasColumnType("int");
        }
    }

    // Role
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class RoleConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
            : this("dbo")
        {
        }

        public RoleConfiguration(string schema)
        {
            ToTable(schema + ".Role");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Name).HasColumnName(@"Name").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Description).HasColumnName(@"Description").IsOptional().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.OpTime).HasColumnName(@"OpTime").IsOptional().HasColumnType("datetime");
            Property(x => x.Opration).HasColumnName(@"Opration").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
        }
    }

    // RoleActionInfo
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class RoleActionInfoConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<RoleActionInfo>
    {
        public RoleActionInfoConfiguration()
            : this("dbo")
        {
        }

        public RoleActionInfoConfiguration(string schema)
        {
            ToTable(schema + ".RoleActionInfo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.RoleId).HasColumnName(@"RoleId").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.ActionId).HasColumnName(@"ActionId").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.IsUsed).HasColumnName(@"IsUsed").IsRequired().HasColumnType("bit");

            // Foreign keys
            HasRequired(a => a.ActionInfo).WithMany(b => b.RoleActionInfoes).HasForeignKey(c => c.ActionId).WillCascadeOnDelete(false); // FK_RoleActionInfo_ActionInfo
            HasRequired(a => a.Role).WithMany(b => b.RoleActionInfoes).HasForeignKey(c => c.RoleId).WillCascadeOnDelete(false); // FK_RoleActionInfo_Role
        }
    }

    // User
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class UserConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<User>
    {
        public UserConfiguration()
            : this("dbo")
        {
        }

        public UserConfiguration(string schema)
        {
            ToTable(schema + ".User");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("uniqueidentifier").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Code).HasColumnName(@"Code").IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Name).HasColumnName(@"Name").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Password).HasColumnName(@"Password").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.IsStop).HasColumnName(@"IsStop").IsRequired().HasColumnType("bit");
            Property(x => x.Operator).HasColumnName(@"Operator").IsOptional().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.OpTime).HasColumnName(@"OpTime").IsOptional().HasColumnType("datetime");
        }
    }

    // UserRole
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.21.1.0")]
    public class UserRoleConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
            : this("dbo")
        {
        }

        public UserRoleConfiguration(string schema)
        {
            ToTable(schema + ".UserRole");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName(@"Id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.UserId).HasColumnName(@"UserId").IsRequired().HasColumnType("uniqueidentifier");
            Property(x => x.RoleId).HasColumnName(@"RoleId").IsRequired().HasColumnType("uniqueidentifier");

            // Foreign keys
            HasRequired(a => a.Role).WithMany(b => b.UserRoles).HasForeignKey(c => c.RoleId).WillCascadeOnDelete(false); // FK_UserRole_Role
            HasRequired(a => a.User).WithMany(b => b.UserRoles).HasForeignKey(c => c.UserId).WillCascadeOnDelete(false); // FK_UserRole_User
        }
    }

    #endregion

    #region Stored procedure return models

    #endregion

}
// </auto-generated>

