using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adoNET
{
    public class funzioni
    {
        public static void CreateAlbums(string connectionString)
        {
            string sqlStringCreate = @"
                CREATE TABLE albums
                (
                    [AlbumId] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,
                    [Title] NVARCHAR(160) NOT NULL,
                    [ArtistId] INTEGER NOT NULL,
                    FOREIGN KEY([ArtistId]) REFERENCES artists([ArtistId]) ON DELETE NO ACTION ON UPDATE NO ACTION
                )
            ";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(sqlStringCreate, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        public static void FillAlbums(string connectionString)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string insert = @"INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('1', 'For Those About To Rock We Salute You', '1');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('2', 'Balls to the Wall', '2');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('3', 'Restless and Wild', '2');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('4', 'Let There Be Rock', '1');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('5', 'Big Ones', '3');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('6', 'Jagged Little Pill', '4');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('7', 'Facelift', '5');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('8', 'Warner 25 Anos', '6');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('9', 'Plays Metallica By Four Cellos', '7');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('10', 'Audioslave', '8');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('11', 'Out Of Exile', '8');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('12', 'BackBeat Soundtrack', '9');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('13', 'The Best Of Billy Cobham', '10');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('14', 'Alcohol Fueled Brewtality Live! [Disc 1]', '11');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('15', 'Alcohol Fueled Brewtality Live! [Disc 2]', '11');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('16', 'Black Sabbath', '12');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('17', 'Black Sabbath Vol. 4 (Remaster)', '12');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('18', 'Body Count', '13');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('19', 'Chemical Wedding', '14');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('20', 'The Best Of Buddy Guy - The Millenium Collection', '15');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('21', 'Prenda Minha', '16');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('22', 'Sozinho Remix Ao Vivo', '16');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('23', 'Minha Historia', '17');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('24', 'Afrociberdelia', '18');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('25', 'Da Lama Ao Caos', '18');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('26', 'Acústico MTV [Live]', '19');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('27', 'Cidade Negra - Hits', '19');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('28', 'Na Pista', '20');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('29', 'Axé Bahia 2001', '21');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('30', 'BBC Sessions [Disc 1] [Live]', '22');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('31', 'Bongo Fury', '23');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('32', 'Carnaval 2001', '21');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('33', 'Chill: Brazil (Disc 1)', '24');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('34', 'Chill: Brazil (Disc 2)', '6');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('35', 'Garage Inc. (Disc 1)', '50');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('36', 'Greatest Hits II', '51');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('37', 'Greatest Kiss', '52');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('38', 'Heart of the Night', '53');
INSERT INTO main.albums (AlbumId, Title, ArtistId) VALUES('39', 'International Superhits', '54');
";

                using (SQLiteCommand cmd = new SQLiteCommand(insert, connection))
                {
                    cmd.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
