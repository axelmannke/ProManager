using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;

using Mk.DBConnector;

namespace BusinessLogic
{
    public class Project 
    {
        public long IdProject { get; set; }
        public long IdParent { get; set; }
        public int NodeNr { get; set; }
        public string Label { get; set; }       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Decimal Profit { get; set; }

        public Decimal TotalProfit { get; set; }
        
        public ObservableCollection<Project> SubProjects { get; private set; } = new ObservableCollection<Project>();

        public Project(long IdProject)
        {
            string sql = string.Format("Select * from Projekte where IdProjekte = {0};", IdProject);

            this.IdProject = IdProject;

            DataRow row = Connection.Db.GetDataRow(sql);

            Init(row);
        }

        /// <summary>
        /// row: DataRow, erwartet einen Datensatz aus promanager.project
        /// loadchildren:   True -> Rekursives Laden der Unterprojekte
        /// </summary>
        /// <param name="row"></param>
        /// <param name="loadchildren"></param>
        public Project(DataRow row, bool loadchildren)
        {
            Init(row);

            if (loadchildren)
                LoadChildren();

        }

        /// <summary>
        /// Aufgabe 1b. Laden der Unterprojekte aus der Datenbank
        /// </summary>
        public void LoadChildren()
        {
            
        }

        private void Init(DataRow row)
        {
            IdProject = long.Parse(row[0].ToString());
            IdParent = long.Parse(row[1].ToString());
            NodeNr = int.Parse(row[2].ToString());
            Label = row[3].ToString();
            StartDate = DateTime.Parse(row[4].ToString());
            EndDate = DateTime.Parse(row[5].ToString());
            Profit = Decimal.Parse(row[6].ToString());
        }

        /// <summary>
        /// Aufgabe 1e. Rekursive Berechnung der Gesamtkoste (Profit + Profit der Unterprojekte)
        /// Speichern des Gesamtgewinns in TotalProfit
        /// </summary>
        public void CalcTotalProfit()
        {
            
        }

        

        public override string ToString()
        {
            return this.Label;
        }

        public List<Staff> ProjectStaff = new List<Staff>();

        /// <summary>
        /// Aufgabe 1g. Laden der diesem Projekt zugeordneten Mitarbeiter und speichern in ProjectStaff
        /// </summary>
        public void GetStuff()
        {
               
        }
    }

    public class ProjectViewModel
    {
        public ObservableCollection<Project> Projects { get; private set; } = new ObservableCollection<Project>();

        public ProjectViewModel()
        {

        }

        public void LoadData()
        {
            Projects.Clear();

            string sql = string.Format("SELECT * FROM project WHERE idparent = 0;");

            DataTable t = Connection.Db.GetDataTable(sql);

            foreach(DataRow r in t.Rows)
            {
                Project p = new BusinessLogic.Project(r, true);
                Projects.Add(p);
            }
        }
    }
}
