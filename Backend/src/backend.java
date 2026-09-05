import java.sql.*;

public class backend {

    public static void main(String[] args)
    {
        //SQL query to get product name, just to confirm that we can retrieve information in the Database
        String sql = "SELECT Name FROM Product WHERE CategoryID = 3";

        // Azure MySQL server details provided by Khabylame
        String url = "jdbc:mysql://java-galacticos-server.mysql.database.azure.com:3306/ECommerceDB" + "?useSSL=true" + "&requireSSL=true";
        String username = "backend2";
        String password = "(weCodeBackEnd123!)";

        try {
            // Connection to MySQL server
            Connection connect = DriverManager.getConnection(url, username, password);

            System.out.println("Connected to MySQL Server successfully!");

            Statement statement = connect.createStatement();

            ResultSet rs = statement.executeQuery(sql);

            if (rs.next())
            {
                String name = rs.getString("Name");
                System.out.println("Product Name: " + name);

            } else
            {
                System.out.println("Product with CategoryID 3 was not found.");
            }

            rs.close();
            statement.close();
            connect.close();

        } catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}