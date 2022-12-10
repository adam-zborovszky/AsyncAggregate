using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChopIt
{
    public abstract class Piece
    {
        public double Cost = 0;
    }

    public abstract class Chunk : Piece
    {
        public List<Piece> Pieces = new List<Piece>();
   
        public abstract IAsyncEnumerable<Chunk> AsyncChopper();

        public async Task<Chunk> ChopIt()
        {
            await foreach (var arrangement in AsyncChopper())
            {
                // safety
                if (arrangement == null)
                    continue;

                // recursively cut, then collect pieces and cost
                var chopPieces = new List<Piece>();
                double chopCost = 0;
                foreach (var chopPiece in arrangement.Pieces)
                    if (chopPiece is Chunk chopChunk)
                    {
                        var cut = await chopChunk.ChopIt();
                        chopPieces.AddRange(cut.Pieces);
                        chopCost += cut.Cost;
                    }
                    else
                    {
                        chopPieces.Add(chopPiece);
                        chopCost += chopPiece.Cost;
                    }
                        
                // evaluate version and replace actual results if necessary
                if (chopCost < Cost)
                {
                    Pieces = chopPieces;
                    Cost = chopCost;
                }
                    
            }

            return bestSolution;
        }
    }


    public class WaterTreatmentProblem : Chunk
    {
        public int[] _inletwaterParameters;

        public WaterTreatmentProblem(int[] inletwaterParameters)
        {
            _inletwaterParameters = inletwaterParameters;
        }

        public override async IAsyncEnumerable<version> AsyncChopper()
        {
            for (int i = 0; i < 5; i++)
            {
                var result = new List<Object>();
                await new Task(() =>
                {
                    result.Content!.Add(_inletwaterParameters);
                    Thread.Sleep(10000);
                });
                yield return result;
            }
        }

        
    }




    public async void valami()
    {
        var w = new WaterTreatmentProblem();
        await w.ChopIt();
    }
    



}
