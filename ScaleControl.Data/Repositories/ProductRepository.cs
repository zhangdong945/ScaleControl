using System;
using System.Collections.Generic;
using System.Data;
using ScaleControl.Models.Entities;
using ScaleControl.Models.Interfaces;

namespace ScaleControl.Data.Repositories
{
    /// <summary>
    /// Repository for ProductList (product/goods management) table.
    /// </summary>
    public class ProductRepository : RepositoryBase
    {
        public ProductRepository(IDatabaseConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }

        public ProductInfo GetProductByName(string name)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM ProductList WHERE ProductName = @Name";
                    AddParameter(cmd, "@Name", name);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapProductInfo(reader);
                        }
                    }
                }
            }
            return null;
        }

        public void SaveProduct(ProductInfo product)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                if (product.Id > 0)
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE ProductList SET ProductName = @ProductName, Code = @Code,
                            InputCode = @InputCode, Remark = @Remark, EnableMaxNetLimit = @EnableMaxNetLimit,
                            MaxNetLimit = @MaxNetLimit WHERE Id = @Id";
                        AddParameter(cmd, "@ProductName", product.ProductName);
                        AddParameter(cmd, "@Code", product.Code);
                        AddParameter(cmd, "@InputCode", product.InputCode);
                        AddParameter(cmd, "@Remark", product.Remark);
                        AddParameter(cmd, "@EnableMaxNetLimit", product.EnableMaxNetLimit);
                        AddParameter(cmd, "@MaxNetLimit", product.MaxNetLimit);
                        AddParameter(cmd, "@Id", product.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    using (var cmd = connection.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO ProductList (ProductName, Code, InputCode, Remark, EnableMaxNetLimit, MaxNetLimit)
                            VALUES (@ProductName, @Code, @InputCode, @Remark, @EnableMaxNetLimit, @MaxNetLimit)";
                        AddParameter(cmd, "@ProductName", product.ProductName);
                        AddParameter(cmd, "@Code", product.Code);
                        AddParameter(cmd, "@InputCode", product.InputCode);
                        AddParameter(cmd, "@Remark", product.Remark);
                        AddParameter(cmd, "@EnableMaxNetLimit", product.EnableMaxNetLimit);
                        AddParameter(cmd, "@MaxNetLimit", product.MaxNetLimit);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<ProductInfo> GetProducts(string filter)
        {
            var results = new List<ProductInfo>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    if (string.IsNullOrEmpty(filter))
                    {
                        cmd.CommandText = "SELECT * FROM ProductList ORDER BY ProductName";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM ProductList WHERE ProductName LIKE @Filter OR Code LIKE @Filter OR InputCode LIKE @Filter ORDER BY ProductName";
                        AddParameter(cmd, "@Filter", "%" + filter + "%");
                    }
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(MapProductInfo(reader));
                        }
                    }
                }
            }
            return results;
        }

        private ProductInfo MapProductInfo(IDataReader reader)
        {
            return new ProductInfo
            {
                Id = System.Convert.ToInt64(reader["Id"]),
                ProductName = reader["ProductName"] as string,
                Code = reader["Code"] as string,
                InputCode = reader["InputCode"] as string,
                Remark = reader["Remark"] as string,
                EnableMaxNetLimit = reader["EnableMaxNetLimit"] == DBNull.Value ? false : System.Convert.ToBoolean(reader["EnableMaxNetLimit"]),
                MaxNetLimit = reader["MaxNetLimit"] == DBNull.Value ? 0 : System.Convert.ToInt64(reader["MaxNetLimit"])
            };
        }
    }
}
