using Tekla.Structures.Drawing;
using Tekla.Structures.Datatype;
using Tekla.Structures.Plugins;
using System.Collections.Generic;
using Tekla.Structures.Geometry3d;
using System.Windows.Forms;
using System;
using Tekla.Structures.Model;
using Tekla.Structures.Model.UI;

namespace TeklaVSDemo1
{
    [Tekla.Structures.Plugins.Plugin("TeklaVSDemo1")]
    [Tekla.Structures.Plugins.PluginUserInterface("TeklaVSDemo1.MainForm")]
    public class MainPlugin : PluginBase
    {
        private readonly Model _model;
        public Model model1 { get { return _model; } }
        
        private StructuresData data { get; set; }

        public MainPlugin(StructuresData structData)
        {
            data = structData;
            _model = new Model();
         }
        public override List<InputDefinition> DefineInput()
        {
            Picker pointPicker = new Picker();
            List<InputDefinition> PointList = new List<InputDefinition>();
            Point inputPoints = pointPicker.PickPoint();
            InputDefinition inputDef = new InputDefinition(inputPoints);
            PointList.Add(inputDef);
            return PointList;

            //throw new System.NotImplementedException();
        }

        public override bool Run(List<InputDefinition> input)
        {
            try
            {
                double _height = data.height;
                // Get picked point in Tekla Structures
                Point startpoint = (Point)input[0].GetInput();
                // Calculate the end point of the beam
                Point endPoint = new Point(startpoint);
                endPoint.Z += _height;
                // Create a beam instance
                Beam column = new Beam(startpoint, endPoint);
                column.Profile.ProfileString = "HEA400";

                //Insert beam in model
                column.Insert();


            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return true;
        }
        public void getDetailsBeam()
        {
            Beam beam = new Beam();
            MessageBox.Show(beam.Name);
           
                
        }
    }
}
