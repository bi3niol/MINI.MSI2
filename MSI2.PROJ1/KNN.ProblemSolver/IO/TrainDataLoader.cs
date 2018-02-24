using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KNN.Solver.ProblemEntities;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace KNN.Solver.IO
{
	public class TrainDataLoader
	{
		public List<Point> LoadData(string filePath)
		{
			List<Point> trainData = new List<Point>();
            try {
                using (TextReader fileReader = File.OpenText(filePath))
                {
                    fileReader.ReadLine(); //skip headers record
                    var csv = new CsvReader(fileReader);
                    double x, y;
                    int cls;
                    bool xRes, yRes, clsRes;
                    while (csv.Read())
                    {
                        xRes = double.TryParse(csv.GetField<string>(0), NumberStyles.Any, CultureInfo.InvariantCulture, out x);
                        yRes = double.TryParse(csv.GetField<string>(1), NumberStyles.Any, CultureInfo.InvariantCulture, out y);
                        clsRes = int.TryParse(csv.GetField<string>(2), out cls);
                        if (!xRes || !yRes || !clsRes) {
                            throw new ArgumentException("Plik ma złą strukturę.");
                        }
                        trainData.Add(new Point(x, y, cls));
                    }
                }

                return trainData;
            }
            catch (Exception e) {
                throw new FileLoadException("Nie można otworzyć pliku.");
            }
            
		}
	}
}
