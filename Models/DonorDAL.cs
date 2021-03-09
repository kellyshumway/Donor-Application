using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;

namespace Donor.Models
{
    public class DonorDAL
    {
        string connectionString = @"Server=DESKTOP-84D8825\MSSQLSERVER01;Database=master;Trusted_Connection=True;";

        // get donor list
        public IEnumerable<DonorInfo> GetAllDonors()
        {
            List<DonorInfo> donorList = new List<DonorInfo>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetAllDonors", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    DonorInfo donor = new DonorInfo();
                    donor.ID = Convert.ToInt32(dr["DonorID"].ToString());
                    donor.FirstName = dr["FirstName"].ToString();
                    donor.LastName = dr["LastName"].ToString();
                    donor.Email = dr["Email"].ToString();
                    donor.Donation = Convert.ToDecimal(dr["Donation"].ToString());

                    donorList.Add(donor);
                }
                con.Close();
            }

            return donorList;
        }

        // add donors
        public void AddDonor(DonorInfo donor)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_InsertDonor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", donor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", donor.LastName);
                cmd.Parameters.AddWithValue("@Email", donor.Email);
                cmd.Parameters.AddWithValue("@Donation", donor.Donation);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        // update donors
        public void UpdateDonor(DonorInfo donor)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_UpdateDonor", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DonorID", donor.ID);
                cmd.Parameters.AddWithValue("@FirstName", donor.FirstName);
                cmd.Parameters.AddWithValue("@LastName", donor.LastName);
                cmd.Parameters.AddWithValue("@Email", donor.Email);
                cmd.Parameters.AddWithValue("@Donation", donor.Donation);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // get donor by ID
        public DonorInfo GetDonorByID(int? donorId)
        {
            DonorInfo donor = new DonorInfo();


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetDonorByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DonorID", donorId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    donor.ID = Convert.ToInt32(dr["DonorID"].ToString());
                    donor.FirstName = dr["FirstName"].ToString();
                    donor.LastName = dr["LastName"].ToString();
                    donor.Email = dr["Email"].ToString();
                    donor.Donation = Convert.ToDecimal(dr["Donation"].ToString());
                }

                con.Close();
            }

            return donor;
        }
    }
}
