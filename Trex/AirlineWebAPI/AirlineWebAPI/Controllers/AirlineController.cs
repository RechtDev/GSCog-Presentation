using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineWebAPI.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AirlineController : Controller
    {
        private IConfiguration _config;

        public AirlineController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPatch("UpdateAvailable")]
        public int UpdateAvailable(int id,bool avail)
        {
            int result = 0;

            string connection = _config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            using(SqlConnection conn = new(connection))
            {
                SqlCommand cmd = new()
                {
                    CommandText = "ChangeAirline",
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sp = new()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = id,
                    Direction = ParameterDirection.Input
                };

                SqlParameter sp2 = new()
                {
                    ParameterName = "@avail",
                    SqlDbType = SqlDbType.Bit,
                    Value = avail,
                    Direction = ParameterDirection.Input
                };

                cmd.Parameters.Add(sp);
                cmd.Parameters.Add(sp2);

                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        [HttpPost("NewCity")]
        public int NewCity(string name)
        {
            int result = 0;

            string connection = _config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            using (SqlConnection conn = new(connection))
            {
                SqlCommand cmd = new()
                {
                    CommandText = "NewCity",
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sp = new()
                {
                    ParameterName = "@name",
                    SqlDbType = SqlDbType.VarChar,
                    Value = name,
                    Direction = ParameterDirection.Input
                };


                cmd.Parameters.Add(sp);

                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        [HttpDelete("OldCity")]
        public int OldCity(int id)
        {
            int result = 0;

            string connection = _config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            using (SqlConnection conn = new(connection))
            {
                SqlCommand cmd = new()
                {
                    CommandText = "OldCity",
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sp = new()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = id,
                    Direction = ParameterDirection.Input
                };


                cmd.Parameters.Add(sp);

                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        [HttpPost("NewAir")]
        public int NewAir(string name, bool avail)
        {
            int result = 0;

            string connection = _config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            using (SqlConnection conn = new(connection))
            {
                SqlCommand cmd = new()
                {
                    CommandText = "NewAir",
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sp = new()
                {
                    ParameterName = "@name",
                    SqlDbType = SqlDbType.VarChar,
                    Value = name,
                    Direction = ParameterDirection.Input
                };

                SqlParameter sp2 = new()
                {
                    ParameterName = "@avail",
                    SqlDbType = SqlDbType.Bit,
                    Value = avail,
                    Direction = ParameterDirection.Input
                };

                cmd.Parameters.Add(sp);
                cmd.Parameters.Add(sp2);

                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            return result;
        }

        [HttpDelete("OldAir")]
        public int OldAir(int id)
        {
            int result = 0;

            string connection = _config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;

            using (SqlConnection conn = new(connection))
            {
                SqlCommand cmd = new()
                {
                    CommandText = "OldAir",
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure
                };

                SqlParameter sp = new()
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = id,
                    Direction = ParameterDirection.Input
                };


                cmd.Parameters.Add(sp);

                conn.Open();

                result = cmd.ExecuteNonQuery();
            }
            return result;
        }
    }
}
