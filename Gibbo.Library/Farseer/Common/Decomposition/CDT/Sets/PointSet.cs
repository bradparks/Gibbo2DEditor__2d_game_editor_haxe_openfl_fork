﻿#region Copyrights
/*
Gibbo2D - Copyright - 2013 Gibbo2D Team
Founders - Joao Alves <joao.cpp.sca@gmail.com> and Luis Fernandes <luisapidcloud@hotmail.com>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. 
*/
#endregion
using System.Collections.Generic;
using FarseerPhysics.Common.Decomposition.CDT.Delaunay;

namespace FarseerPhysics.Common.Decomposition.CDT.Sets
{
    internal class PointSet : Triangulatable
    {
        public PointSet(List<TriangulationPoint> points)
        {
            Points = new List<TriangulationPoint>(points);
        }

        #region Triangulatable Members

        public IList<TriangulationPoint> Points { get; private set; }
        public IList<DelaunayTriangle> Triangles { get; private set; }

        public virtual TriangulationMode TriangulationMode
        {
            get { return TriangulationMode.Unconstrained; }
        }

        public void AddTriangle(DelaunayTriangle t)
        {
            Triangles.Add(t);
        }

        public void AddTriangles(IEnumerable<DelaunayTriangle> list)
        {
            foreach (DelaunayTriangle tri in list) Triangles.Add(tri);
        }

        public void ClearTriangles()
        {
            Triangles.Clear();
        }

        public virtual void PrepareTriangulation(TriangulationContext tcx)
        {
            if (Triangles == null)
            {
                Triangles = new List<DelaunayTriangle>(Points.Count);
            }
            else
            {
                Triangles.Clear();
            }
            tcx.Points.AddRange(Points);
        }

        #endregion
    }
}