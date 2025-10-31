using IdentityProject.Models.ViewModels.DirectDatabase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace IdentityProject.Controllers
{
    [AllowAnonymous]
    public class DirectDataBaseController : Controller
    {        
        private readonly IConfiguration _configuration;

        public DirectDataBaseController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IActionResult Index()
        {
            List<CityStateCountryViewModel> model = GetData();
            return View(model);
        }

        [HttpGet]
        public IActionResult GetCustomerOrder()
        {
            List<CustomerAndItemsViewModel> model = GetCustomerData();
            return View(model);
        }

        [HttpPost]
        public IActionResult GetCustomerOrder(string CustName)
        {
            int IsSuccess = AdNewCustomer(CustName);
            return RedirectToAction("GetCustomerOrder");
        }

        private List<CustomerAndItemsViewModel> GetCustomerData()
        {
            var CustList = new List<CustomerAndItemsViewModel>();
            string querySp = "comm.GetCustomers";
            string constr = _configuration.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlDataAdapter da = new SqlDataAdapter(querySp, con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                da.Fill(ds, "Customers");

                CustList.AddRange(from datarow in ds.Tables["Customers"].AsEnumerable()
                                  select new CustomerAndItemsViewModel
                                  {
                                      Id = Convert.ToInt32(datarow["Id"]),
                                      CustomerName = Convert.ToString(datarow["CName"])                                      
                                  });
            }

            return CustList;
        }

        private int AdNewCustomer(string name)
        {
            string querySp = "AddCustomerAndOrders";
            string constr = _configuration.GetConnectionString("DefaultConnection");

            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(querySp, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Custname", name.ToString());

                SqlParameter out1 = new SqlParameter
                {
                    ParameterName = "@CustID", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Int, //Data Type of Parameter                    
                    Direction = ParameterDirection.Output //Specify the parameter as input
                };

                SqlParameter out2 = new SqlParameter
                {
                    ParameterName = "@IsSuccess", //Parameter name defined in stored procedure
                    SqlDbType = SqlDbType.Int, //Data Type of Parameter                    
                    Direction = ParameterDirection.Output //Specify the parameter as input
                };

                cmd.Parameters.Add(out1);
                cmd.Parameters.Add(out2);

                con.Open();
                cmd.ExecuteNonQuery();
                
                var CustId = out1.Value.ToString();
                var IsSuccess = Convert.ToInt32(out2.Value);

                return IsSuccess;
            }
        }


        private List<CityStateCountryViewModel> GetData()
        {
            string constr = _configuration.GetConnectionString("DefaultConnection");
            List<CityStateCountryViewModel> model = new List<CityStateCountryViewModel>();

            using(SqlConnection con = new SqlConnection(constr))
            {
                string query = "Exec comm.GetCityStateCountry";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            model.Add(new CityStateCountryViewModel
                            {
                                CityId = Convert.ToInt32(sdr["CityId"]),
                                CityName = sdr["CityName"].ToString(),
                                CountryId = Convert.ToInt32(sdr["CountryId"]),
                                Countryname = sdr["CountryName"].ToString()
                            });
                        }
                    }

                    con.Close();
                }

                return model;
            }
        }
    }
}
