﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DS.Projeto.Controller {
	public class Connector {

		private static SqlConnection _conn = null;
		private static string _connString =
			  "Data Source=127.0.0.1;"
			+ "Initial Catalog=banco;"
			+ "User id=sa;"
			+ "Password=info211;";

		private static void connect() {
			if(Connector._conn == null) {
				Connector._conn = new SqlConnection(Connector._connString);
			}
			Connector._conn.Open();
		}

		private static void close() {
			if (Connector._conn != null) {
				Connector._conn.Close();
				Connector._conn = null;
			}
		}

		public static int execute(string command) {
			Connector.connect();
			SqlCommand statement = new SqlCommand(command, Connector._conn);
			int rowsAffected = statement.ExecuteNonQuery();
			Connector.close();
			return rowsAffected;
		}
	}
}
