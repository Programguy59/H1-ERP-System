using System.Data.SqlClient;

namespace H1_ERP_System.util;

public class DatabaseServer
{
	public static SqlConnection GetConnection()
	{
		SqlConnectionStringBuilder sb = new()
		{
			DataSource = "docker.data.techcollege.dk",
			InitialCatalog = "H1PD021123_Gruppe3",
			UserID = "H1PD021123_Gruppe3",
			Password = "H1PD021123_Gruppe3"
		};
		
		var connectionString = sb.ToString();
		var connection = new SqlConnection(connectionString);
		
		return connection;
	}
}
