using mkz_school_service.Models;
using mkz_school_service.Models.Communication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace mkz_school_service.DataAccess
{
    public class StudentAccess
    {
        public static List<SC_STUDENT> GetAll()
        {
            List<SC_STUDENT> studentList = new List<SC_STUDENT>();

            using (SqlConnection sqlConnection = new SqlConnection(Connection.SchoolDB))
            {
                string procedureName = "PROC_STUDENT_SELECT";

                SqlCommand sqlCommand = new SqlCommand(procedureName, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    sqlConnection.Open();

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        studentList.Add(new SC_STUDENT()
                        {
                            STD_ID = Guid.Parse(sqlDataReader["STD_ID"].ToString()),
                            STD_NAME = sqlDataReader["STD_NAME"].ToString(),
                            STD_LAST_NAME = sqlDataReader["STD_LAST_NAME"].ToString(),
                            STD_BIRTH_DATE = Utility.UDate.ConvertDateOrNull(sqlDataReader["STD_BIRTH_DATE"].ToString()),
                            STD_EMAIL = sqlDataReader["STD_EMAIL"].ToString(),
                            STD_IMAGE = sqlDataReader["STD_IMAGE"].ToString(),
                            STD_FULL_NAME = sqlDataReader["STD_FULL_NAME"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    if (!(sqlConnection is null))
                    {
                        sqlConnection.Close();
                    }
                }
            }


            return studentList;
        }

        public static ResponseBase CreateOrUpdate(SC_STUDENT student)
        {
            ResponseBase baseResponse = new ResponseBase();

            using (SqlConnection sqlConnection = new SqlConnection(Connection.SchoolDB))
            {
                string procedureName = "PROC_STUDENT_INSERT_OR_UPDATE";

                SqlCommand sqlCommand = new SqlCommand(procedureName, sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue("@V_STD_ID", Utility.UGuid.GuidOrNull(student.STD_ID));
                sqlCommand.Parameters.AddWithValue("@V_STD_NAME", student.STD_NAME);
                sqlCommand.Parameters.AddWithValue("@V_STD_LAST_NAME", student.STD_LAST_NAME);
                sqlCommand.Parameters.AddWithValue("@V_STD_BIRTH_DATE", student.STD_BIRTH_DATE);
                sqlCommand.Parameters.AddWithValue("@V_STD_IMAGE", student.STD_IMAGE);
                sqlCommand.Parameters.AddWithValue("@V_STD_EMAIL", student.STD_EMAIL);
                sqlCommand.Parameters.AddWithValue("@V_STD_ACTIVE", student.STD_ACTIVE);

                sqlCommand.Parameters.Add(ResponseBase.IS_SUCCESS_PARAMETER, SqlDbType.Bit,int.MaxValue).Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(ResponseBase.STATUS_CODE_PARAMETER, SqlDbType.VarChar,10).Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(ResponseBase.STATUS_MESSAGE_PARAMETER, SqlDbType.VarChar,350).Direction = System.Data.ParameterDirection.Output;
                sqlCommand.Parameters.Add(ResponseBase.GENERATED_ID_PARAMETER, SqlDbType.UniqueIdentifier,int.MaxValue).Direction = System.Data.ParameterDirection.Output;

                try
                {
                    sqlConnection.Open();

                    sqlCommand.ExecuteNonQuery();

                    baseResponse.IsSuccess = Convert.ToBoolean(sqlCommand.Parameters[ResponseBase.IS_SUCCESS_PARAMETER].Value);
                    baseResponse.StatusCode = Convert.ToString(sqlCommand.Parameters[ResponseBase.STATUS_CODE_PARAMETER].Value);
                    baseResponse.Message = Convert.ToString(sqlCommand.Parameters[ResponseBase.STATUS_MESSAGE_PARAMETER].Value);

                    if (baseResponse.IsSuccess)
                    {
                        student.STD_ID = Guid.Parse(Convert.ToString(sqlCommand.Parameters[ResponseBase.GENERATED_ID_PARAMETER].Value));
                        baseResponse.Data = student;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }
                finally
                {
                    if (!(sqlConnection is null))
                    {
                        sqlConnection.Close();
                    }
                }
            }


            return baseResponse;
        }
    }
}
