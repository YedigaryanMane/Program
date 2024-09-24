using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp74
{

    public class Direction 
    {
        
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public decimal Price { get; set; }
        public double Distance { get; set; }

        public const string CONNECTION_STRING = "Data Source=.;Initial Catalog = CarsDb; Integrated Security = True; Encrypt=False";
        List<Direction> directions = new List<Direction>();
        public void Add(Direction direction)
        {
            using(SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                        List<Direction> directions = new List<Direction>();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = "insert into Direction values(@Id,@To1 ,@From1,@Price,@Distance )";
                    command.Parameters.Add(new SqlParameter("@Id",direction.Id));
                    command.Parameters.Add(new SqlParameter("@To1",direction.To));
                    command.Parameters.Add(new SqlParameter("@From1",direction.From));
                    command.Parameters.Add(new SqlParameter("@Price",direction.Price));
                    command.Parameters.Add(new SqlParameter("@Distance",direction.Distance));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
           using (SqlConnection conn = new SqlConnection(CONNECTION_STRING))
            {

            conn.Open();
                
                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection= conn;
                    command.CommandText= "Delete from Direction where id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id",id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Direction direction)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Update Direction set Id = @Id,To1 =@To1,From1 = @From1,Price = @Price,Distance = @Distance";
                    command.Parameters.Add(new SqlParameter("@Id", direction.Id));
                    command.Parameters.Add(new SqlParameter("@To1", direction.To));
                    command.Parameters.Add(new SqlParameter("@From1", direction.From));
                    command.Parameters.Add(new SqlParameter("@Price", direction.Price));
                    command.Parameters.Add(new SqlParameter("@Distance", direction.Distance));

                    command.ExecuteNonQuery();

                }
            }
        }


        public List<Direction> GetAll()
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                List<Direction> list = new List<Direction>();

                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection= con;
                    command.CommandText = "select * from Direction";

                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        Direction direction = new Direction();

                        while (reader.Read())
                        {
                            direction.Id = int.Parse(reader["Id"].ToString());
                            direction.To = reader["To1"].ToString();
                            direction.From = reader["From1"].ToString();
                            direction.Price = decimal.Parse(reader["Price"].ToString());
                            direction.Distance = int.Parse(reader["Distance"].ToString());
                            list.Add(direction);
                        }
                    }
                
                }
                return list;
            }
        }

        public Direction GetByiD(int id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                Direction direction = new Direction();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection= con;
                    command.CommandText = "select * from Diorection where id = @Id";
                    command.Parameters.Add(new SqlParameter("@Id",id));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            direction.Id = int.Parse(reader["Id"].ToString());
                            direction.To = reader["To1"].ToString();
                            direction.From = reader["From1"].ToString();
                            direction.Price = decimal.Parse(reader["Price"].ToString());
                            direction.Distance = int.Parse(reader["Distance"].ToString());

                        }
                    }
                }
                return direction;
            }
        }
    }


    public class CarType 
    {

        public int Id { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public float Coef { get; set; }

        public const string CONNECTION_STRING = "Data Source=.;Initial Catalog = CarsDb; Integrated Security = True; Encrypt=False";
        List<CarType> carTypes = new List<CarType>();

        public void AddCar(CarType carType)
        {
            using(SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = "insert into CarType values(@Id,@Model,@Price,@Coef)";
                    command.Parameters.Add(new SqlParameter("@Id",carType.Id));
                    command.Parameters.Add(new SqlParameter("@Model", carType.Model));
                    command.Parameters.Add(new SqlParameter("@Price",carType.Price));
                    command.Parameters.Add(new SqlParameter("@Coef",carType.Coef));

                    command.ExecuteNonQuery();  
                }
            }

        }

        public void Delete(int id)
        {
            using(SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = "Delete from CarType where id = @Id";

                    command.Parameters.Add(new SqlParameter("id", id));

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<CarType> GetAllCar()
        {
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                List<CarType> cars = new List<CarType>();

                using(SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "select * from CarType ";

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CarType car = new CarType();
                            car.Id = int.Parse(reader["@Id"].ToString());
                            car.Model = reader["@Model"].ToString();
                            car.Price =decimal.Parse(reader["@Price"].ToString());
                            car.Coef = float.Parse(reader["@Coef"].ToString());
                            cars.Add(car);
                        }
                    }
                }
                return cars;
            }
        }

        public CarType GetCar(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                CarType car = new CarType();
                using (SqlCommand sqlCommand = new SqlCommand())
                {
                    sqlCommand.Connection = connection;
                    sqlCommand.CommandText = "select * from CarType where id = @Id ";
                    sqlCommand.Parameters.Add(new SqlParameter("@Id",car.Id));
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            car.Id = int.Parse(reader["@Id"].ToString());
                            car.Model = reader["@Model"].ToString();
                            car.Price = decimal.Parse(reader["@Price"].ToString());
                            car.Coef = float.Parse(reader["@Coef"].ToString());
                            
                        }
                    }
                }
                return car;
            }
        }

        public void Update(CarType carType)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "Update CarType set Id = @Id, Model = @Model,Price = @Price,Coef = @Coef";
                    cmd.Parameters.Add(new SqlParameter("@Id", carType.Id));
                    cmd.Parameters.Add(new SqlParameter("@Model", carType.Model));
                    cmd.Parameters.Add(new SqlParameter("@Price",carType.Price));
                    cmd.Parameters.Add(new SqlParameter("@Coef",carType.Coef));

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public class Container 
    {
      

        public int Id { get; set; }
        public float Coef { get; set; }
        public bool IsClosed { get; set; }

        public const string CONNECTION_STRING = "Data Source=.;Initial Catalog = CarsDb; Integrated Security = True; Encrypt=False";
          List<Container> containerList = new List<Container>();
        public void AddCar(Container container)
        {
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "insert into Container values(@Id,@Coef,@IsClosed)";
                    command.Parameters.Add(new SqlParameter("@Id", container.Id));
                    command.Parameters.Add(new SqlParameter("@Coef",container.Coef));
                    command.Parameters.Add(new SqlParameter("@IsClosed",container.IsClosed));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using(SqlConnection connection=new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();

                using(SqlCommand cmd = new SqlCommand())
                {
                cmd.Connection = connection;
                    cmd.CommandText = "Delete from  Container where id = @id ";
                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cmd.ExecuteNonQuery ();
                }
                
            }
        }

        public List<Container> GetAllCar()
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                List<Container> container = new List<Container>();

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Select *from Container";

                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Container container1 = new Container();
                            com.CommandText = "insert into Container values(@Id,@Coef,@IsClosed)";
                             container1.Id = int.Parse(reader["@Id"].ToString());
                            container1.Coef = float.Parse(reader["@Coef"].ToString());
                            container1.IsClosed = reader["@IsClosed"].ToString().Equals("true");

                            container.Add(container1);
                        }

                    }

                }
                return container;
            }
        }

        public Container GetCar(int id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();
                Container container = new Container();

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Select *from Container";

                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            com.CommandText = "insert into Container values(@Id,@Coef,@IsClosed)";
                            container.Id = int.Parse(reader["@Id"].ToString());
                            container.Coef = float.Parse(reader["@Coef"].ToString());
                            container.IsClosed = reader["@IsClosed"].ToString().Equals("true");

                        }

                    }

                }
                return container;
            }
        }

        public void Update(Container container, int id)
        {
            using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "Update Container set id = @Id,Coef = @Coef,IsClosed = @IsClosed where id = @Id";

                    com.Parameters.Add(new SqlParameter("@Id", container.Id));
                    com.Parameters.Add(new SqlParameter("@Coef", container.Coef));
                    com.Parameters.Add(new SqlParameter("@IsClosed", container.IsClosed));

                    com.ExecuteNonQuery();
                }
            }


        }
    }

    public class Crashed 
    {
      

        public int Id { get; set; }
        public bool IsCrashed { get; set; }

        public float Coef {  get; set; }

        public const string CONNECTION_STRING = "Data Source=.;Initial Catalog = CarsDb; Integrated Security = True; Encrypt=False";

        public void AddCar(Crashed crashed)
        {
           using(SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open();

                using(SqlCommand command = new SqlCommand())
                {
                    command.Connection = con;
                    command.CommandText = "insert onto Crashed vsalues(@Id,@IsCrashed)";

                    command.Parameters.Add(new SqlParameter("@Id", crashed.Id));
                    command.Parameters.Add(new SqlParameter("@IsCrashed",crashed.IsCrashed));
                    command.Parameters.Add(new SqlParameter("@Coef", crashed.Coef));

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using(SqlConnection con = new SqlConnection(CONNECTION_STRING))
            {
                con.Open() ;

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "Delete from Crashed where id = @Id";

                    cmd.Parameters.Add(new SqlParameter("@Id", id));

                    cmd.ExecuteNonQuery() ;
                }
            }
        }

        public List<Crashed> GetAllCar()
        {
           using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                List<Crashed> crasheds = new List<Crashed>();

                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from mCrashed";

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Crashed crashed = new Crashed();
                            crashed.Coef = float.Parse(reader["@Coef"].ToString());
                            crashed.Id = int.Parse(reader["@Id"].ToString());
                            crashed.IsCrashed = reader["@IsCrashed"].ToString().Equals("true");

                            crasheds.Add(crashed);

                        }
                    }
;
                }
                return crasheds;
            }
        }

        public Crashed GetCar(int id)
        {
            using (SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                Crashed crashed1 = new Crashed();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "select * from mCrashed";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            crashed1.Coef = float.Parse(reader["@Coef"].ToString());
                            crashed1.Id = int.Parse(reader["@Id"].ToString());
                            crashed1.IsCrashed = reader["@IsCrashed"].ToString().Equals("true");


                        }
                    }
;
                }
                return crashed1;
            }
        }

        public void Update(Crashed crashed, int id)
        {
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Open();
                using(SqlCommand cmd = new SqlCommand()) 
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "Update Crashed set Id = @Id,Coef = @Coef,IsCrashed = @IsCrashed where id = @Id ";

                        cmd.Parameters.Add(new SqlParameter("@Id", crashed.Id));
                        cmd.Parameters.Add(new SqlParameter("@IsCrashed", crashed.IsCrashed));
                        cmd.Parameters.Add(new SqlParameter("@Coef", crashed.Coef));

                        cmd.ExecuteNonQuery();
                    }
            }
        }
    }
  
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
