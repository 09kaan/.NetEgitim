/*
COUNT → Kaç satır var?
AVG   → Ortalama nedir?
MIN   → En küçük değer nedir?
MAX   → En büyük değer nedir?
*/

using Microsoft.Data.Sqlite;

using SqliteConnection connection = new(
    "Data Source=products.db"
);

connection.Open();                

Console.Write("Minimum fiyatı gir: ");

string? input = Console.ReadLine();

if (!double.TryParse(input, out double minimumPrice))
{
    Console.WriteLine(
        "Geçerli bir fiyat girmelisin."
    );

    return;
}

string parameterSql = """
    SELECT Id, Name, Price
    FROM Products
    WHERE CAST(Price AS REAL) >= $minimumPrice
    ORDER BY CAST(Price AS REAL) ASC;
    """;

using SqliteCommand parameterCommand = new(
    parameterSql,
    connection
);

parameterCommand.Parameters.AddWithValue(
    "$minimumPrice",
    minimumPrice
);

using SqliteDataReader parameterReader =
    parameterCommand.ExecuteReader();

while (parameterReader.Read())
{
    int id = parameterReader.GetInt32(0);
    string name = parameterReader.GetString(1);
    object price = parameterReader.GetValue(2);

    Console.WriteLine(
        $"ID: {id} | Ürün: {name} | Fiyat: {price}"
    );
}





                                                        //Parantez içinde * olunca tüm satırları say demekmiş. All gibi
                                                        //Price koyarsak sadece Priceı olanları sayar mesela
/*
string countSql = """
    SELECT COUNT(*)
    FROM Products;
    """;

using SqliteCommand countCommand = new(
    countSql,
    connection
);

long productCount =
    (long)countCommand.ExecuteScalar()!;                //Tek bir sonuç almak için ExecuteScalar()

Console.WriteLine(
    $"Toplam ürün sayısı: {productCount}"
);

string averageSql = """
    SELECT AVG(CAST(Price AS REAL))
    FROM Products;
    """;

using SqliteCommand averageCommand = new(
    averageSql,
    connection
);

double averagePrice = Convert.ToDouble(
    averageCommand.ExecuteScalar()
);

Console.WriteLine(
    $"Ortalama fiyat: {averagePrice}"
);

string priceSummarySql = """
    SELECT
        MIN(CAST(Price AS REAL)),
        MAX(CAST(Price AS REAL))
    FROM Products;
    """;

using SqliteCommand priceSummaryCommand = new(
    priceSummarySql,
    connection
);

using SqliteDataReader priceSummaryReader =
    priceSummaryCommand.ExecuteReader();

if (priceSummaryReader.Read())
{
    double minimumPrice = Convert.ToDouble(
        priceSummaryReader.GetValue(0)
    );

    double maximumPrice = Convert.ToDouble(
        priceSummaryReader.GetValue(1)
    );

    Console.WriteLine(
        $"En düşük fiyat: {minimumPrice}"
    );

    Console.WriteLine(
        $"En yüksek fiyat: {maximumPrice}"
    );
}

/*
string updateSql = """
    UPDATE Products
    SET Price = 600
    WHERE Name = 'Mouse';
    """;

using SqliteCommand updateCommand = new(
    updateSql,
    connection
);

int updatedRows =
    updateCommand.ExecuteNonQuery();                   //INSERT,UPDATE,DELETE için ExecuteNonQuery()

Console.WriteLine(
    $"{updatedRows} ürün güncellendi."
);

string deleteSql = """
    DELETE FROM Products
    WHERE Name = 'Mouse';
    """;

using SqliteCommand deleteCommand = new(
    deleteSql,
    connection
);


int deletedRows =
    deleteCommand.ExecuteNonQuery();

Console.WriteLine(
    $"{deletedRows} ürün silindi."
);



                                                    //Price string tutuluyormuş onu çevirmek için CAST(Price AS REAL) yaptık
                                                    //DESC descending azalan ASC ascending artan
string sql = """
    SELECT Id, Name, Price
    FROM Products
    WHERE CAST(Price AS REAL) >= 500           
      AND CAST(Price AS REAL) <= 2000   
    ORDER BY CAST(Price AS REAL) ASC;
    """;

using SqliteCommand command = new(
    sql,
    connection
);

using SqliteDataReader reader =
    command.ExecuteReader();                        //Birden fazla satır ve sütun okumak için ExecuteReader()

bool productFound = false;

while (reader.Read())
{
    productFound = true;

    int id = reader.GetInt32(0);
    string name = reader.GetString(1);
    object price = reader.GetValue(2);

    Console.WriteLine(
        $"ID: {id} | Ürün: {name} | Fiyat: {price}"
    );
}

if (!productFound)
{
    Console.WriteLine("Veritabanında ürün bulunamadı.");
}
*/