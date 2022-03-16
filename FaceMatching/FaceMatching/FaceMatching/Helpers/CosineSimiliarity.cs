using FaceRecognitionDotNet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaceMatching.Helpers
{
    public class CosineSimiliarity
    {

        public static IEnumerable<double> CalculateCosine(IEnumerable<FaceEncoding> faceEncodings, FaceEncoding faceToCompare)
        {
            if (faceEncodings == null)
                throw new ArgumentNullException(nameof(faceEncodings));

            if (faceToCompare == null)
                throw new ArgumentNullException(nameof(faceToCompare));

            var array = faceEncodings.ToArray();
            if (array.Any(encoding => encoding.IsDisposed))
                throw new ObjectDisposedException($"{nameof(faceEncodings)} contains disposed object.");


            var results = new List<double>();

            if (array.Length == 0)
                return results;

            double numerator = 0d;
            double normA = 0d;
            double normB = 0d;
            double denominator = 0d;

            foreach (var faceEncoding in array)
            {
                var tempEn = faceEncoding.GetRawEncoding();
                var tempTo = faceToCompare.GetRawEncoding();

                if (tempEn.Count() == tempTo.Count())
                {
                    for(int i = 0; i < tempEn.Count(); i++)
                    {
                        numerator += tempEn[i] * tempTo[i];
                        normA += Math.Pow(tempEn[i], 2d);
                        normB += Math.Pow(tempTo[i], 2d);
                    }
                    denominator = Math.Sqrt(normA) * Math.Sqrt(normB);
                }

                // Cosine Distance
                results.Add(1 - (numerator / denominator));
            }


            return results;
        }


    }
}
