using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MS_4._2
{
    public partial class Form1 : Form
    {
        List<Gruppo> elegruppi = new List<Gruppo>();
        List<Disciplina> elediscipline = new List<Disciplina>();
        List<Atleta> eleatleti = new List<Atleta>();
        public Form1()
        {
            InitializeComponent();
            #region inizializzazione
            var gruppo1 = new Gruppo("Veloci", "Via Papa Giovanni", "Silvio Berlusconi", "035 678 8778", "alpha@gmail.com");            
            var gruppo2 = new Gruppo("Belli", "Via Broseta", "Steve Jobs", "035 452 2133", "beta@gmail.com");
            var gruppo3 = new Gruppo("Forti", "Via Europa", "Bill Gates", "035 122 4352", "gamma@gmail.com");
            elegruppi.Add(gruppo1);
            elegruppi.Add(gruppo2);
            elegruppi.Add(gruppo3);

            var disciplina1 = new Disciplina("Corsa", 20, 40, 60);
            var disciplina2 = new Disciplina("Salto", 30, 50, 70);
            var disciplina3 = new Disciplina("Nuoto", 40, 60, 80);
            elediscipline.Add(disciplina1);
            elediscipline.Add(disciplina2);
            elediscipline.Add(disciplina3);

            var atleta1 = new Atleta("Alfa", "Mario Rossi", DateTime.Parse("12/10/2020"), "Marco", "Bianchi", DateTime.Parse("13/08/1990"), "Bergamo", gruppo1, disciplina2, "Junior", 60);
            var atleta2 = new Atleta("Beta", "Giuseppe Verdi", DateTime.Parse("17/09/2019"), "Daniele", "Fumagalli", DateTime.Parse("13/10/1986"), "Napoli", gruppo2, disciplina3, "Senior", 90);
            var atleta3 = new Atleta("Gamma", "Danilo Rossi", DateTime.Parse("26/01/2020"), "Silvio", "Ferrari", DateTime.Parse("15/07/1998"), "roma", gruppo1, disciplina1, "Dilettanti", 60);
            eleatleti.Add(atleta1);
            eleatleti.Add(atleta2);
            eleatleti.Add(atleta3);

            combo_view_disciplina.Text = "Tutto";
            combo_view_gruppo.Text = "Tutto";
            combo_view_livello.Text = "Tutto";
            #endregion
        }

        private void Btn_ins_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl2.SelectedTab == pag_ins_gruppo)
                {
                    Gruppo nuovogruppo = default(Gruppo);
                    nuovogruppo = new Gruppo(Txt_ragione.Text, Txt_indirizzo.Text, Txt_presidente.Text, Txt_telefono.Text, Txt_mail.Text);
                    elegruppi.Add(nuovogruppo);
                }
                if (tabControl2.SelectedTab == pag_ins_disciplina)
                {
                    Disciplina nuovadisciplina = default(Disciplina);
                    nuovadisciplina = new Disciplina(Txt_disciplina.Text, Convert.ToInt32(num_dilettanti.Value), Convert.ToInt32(num_junior.Value), Convert.ToInt32(num_senior.Value));
                    elediscipline.Add(nuovadisciplina);
                }
                if (tabControl2.SelectedTab == pag_ins_atleta)
                {
                    Atleta nuovoatleta = default(Atleta);
                    nuovoatleta = new Atleta(Txt_codice.Text, Txt_medico.Text, DateTime.Parse(Txt_data.Text), Txt_nome.Text, Txt_cognome.Text, DateTime.Parse(Txt_nascita.Text), Txt_città.Text, elegruppi.FirstOrDefault(a => a.ragioneSociale == combo_gruppo.Text), elediscipline.FirstOrDefault(a => a.nomeDisciplina == combo_disciplina.Text), combo_livello.Text, Convert.ToInt32(num_punteggio.Value));
                    eleatleti.Add(nuovoatleta);                    
                }
                Funzioni.Clear(tabControl2);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }       
        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_gruppo.Items.Clear();
            foreach(var gruppo in elegruppi)
            {
                combo_gruppo.Items.Add(gruppo.ragioneSociale);
            }
            combo_disciplina.Items.Clear();
            foreach (var disciplina in elediscipline)
            {
                combo_disciplina.Items.Add(disciplina.nomeDisciplina);
            }            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            data_mod.DataSource = elegruppi.ToList();
            combo_view_disciplina.Items.Clear();
            combo_view_disciplina.Items.Add("Tutto");
            foreach (var disciplina in elediscipline)
            {
                combo_view_disciplina.Items.Add(disciplina.nomeDisciplina);
            }
            combo_view_gruppo.Items.Clear();
            combo_view_gruppo.Items.Add("Tutto");
            foreach (var gruppo in elegruppi)
            {
                combo_view_gruppo.Items.Add(gruppo.ragioneSociale);
            }
            Funzioni.Select(data_visualizza, eleatleti);
        }

        private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == pag_mod_gruppo)
            {
                data_mod.DataSource = elegruppi.ToList();
            }
            if (tabControl3.SelectedTab == pag_mod_disciplina)
            {
                data_mod.DataSource = elediscipline.ToList();
            }
            if (tabControl3.SelectedTab == pag_mod_atleta)
            {
                Funzioni.Select(data_mod, eleatleti);
            }
        }

        private void Btn_cerca_Click(object sender, EventArgs e)
        {
            data_mod.ClearSelection();
            string cerca = Txt_cerca.Text;
            foreach (DataGridViewRow row in data_mod.Rows)
            {
                if (string.Compare(cerca, row.Cells[0].Value.ToString())==0)
                {
                    row.Selected = true;
                    Funzioni.Riempimento(tabControl3, data_mod);
                    Txt_cerca.Clear();
                    Btn_mod.Enabled = true;
                    return;
                }
            }
            MessageBox.Show("Nessun elemento trovato.");
        }

        private void data_mod_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Funzioni.Riempimento(tabControl3, data_mod);
            Btn_mod.Enabled = true;
        }

        private void Btn_mod_Click(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == pag_mod_gruppo)
            {
                string mod = Txt_mod_ragione.Text;
                var listmod = elegruppi.Where(p => p.ragioneSociale == mod).First();

                try
                {
                    listmod.indirizzo = Txt_mod_indirizzo.Text;
                    listmod.presidente = Txt_mod_presidente.Text;
                    listmod.telefono = Txt_mod_telefono.Text;
                    listmod.mail = Txt_mod_mail.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            if (tabControl3.SelectedTab == pag_mod_disciplina)
            {
                string mod = Txt_mod_disciplina.Text;
                var listmod = elediscipline.Where(p => p.nomeDisciplina == mod).First();

                try
                {
                    listmod.Dilettanti = Convert.ToInt32(num_mod_dilettanti.Value);
                    listmod.Junior = Convert.ToInt32(num_mod_junior.Value);
                    listmod.Senior = Convert.ToInt32(num_mod_senior.Value);
                    foreach(Atleta atleta in eleatleti)
                    {
                        if (atleta.disciplina.nomeDisciplina == mod)
                        {
                            if(atleta.punteggio < (int)atleta.disciplina.GetType().GetProperty(atleta.livello).GetValue(atleta.disciplina, null))
                            {
                                atleta.idoneità = false;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            if (tabControl3.SelectedTab == pag_mod_atleta)
            {
                string mod = Txt_mod_codice.Text;
                var listmod = eleatleti.Where(p => p.codice == mod).First();

                try
                {
                    listmod.medico = Txt_mod_medico.Text;
                    listmod.dataCertificato = DateTime.Parse(Txt_mod_certificato.Text);
                    listmod.nome = Txt_mod_nome.Text;
                    listmod.cognome = Txt_mod_cognome.Text;
                    listmod.nascita = DateTime.Parse(Txt_mod_nascita.Text);
                    listmod.città = Txt_mod_citta.Text;
                    listmod.gruppo = elegruppi.FirstOrDefault(a => a.ragioneSociale == combo_mod_gruppo.Text);
                    listmod.disciplina = elediscipline.FirstOrDefault(a => a.nomeDisciplina == combo_mod_gruppo.Text);
                    listmod.livello = combo_mod_livello.Text;
                    listmod.punteggio = Convert.ToInt32(num_mod_punteggio.Value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            Funzioni.Clear(tabControl3);
            data_mod.Refresh();
            Btn_mod.Enabled = false;
        }
        private void Txt_cerca_TextChanged(object sender, EventArgs e)
        {
            if (tabControl3.SelectedTab == pag_mod_gruppo)
            {
                var zz = elegruppi.Where(p => p.ragioneSociale.ToUpper().Contains(Txt_cerca.Text.ToUpper())).ToList();
                data_mod.DataSource = zz.ToList();
            }
            if (tabControl3.SelectedTab == pag_mod_disciplina)
            {
                var zz = elediscipline.Where(p => p.nomeDisciplina.ToUpper().Contains(Txt_cerca.Text.ToUpper())).ToList();
                data_mod.DataSource = zz.ToList();
            }
            if (tabControl3.SelectedTab == pag_mod_atleta)
            {
                var zz = eleatleti.Where(p => p.codice.ToUpper().Contains(Txt_cerca.Text.ToUpper())).ToList();
                Funzioni.Select(data_mod, zz);
            }
        }
        private void rb_gruppo_CheckedChanged(object sender, EventArgs e)
        {
            Data_canc.DataSource = elegruppi.ToList();
        }

        private void rb_disciplina_CheckedChanged(object sender, EventArgs e)
        {
            Data_canc.DataSource = elediscipline.ToList();
        }

        private void Rb_atleti_CheckedChanged(object sender, EventArgs e)
        {
            Funzioni.Select(Data_canc, eleatleti);
        }

        private void Btn_canc_Click(object sender, EventArgs e)
        {
            int numcanc = default(int);
            string keycanc = Txt_canc.Text;
            if (!string.IsNullOrEmpty(Txt_canc.Text))
            {
                if (rb_gruppo.Checked)
                {
                    eleatleti.RemoveAll(a => a.gruppo.ragioneSociale == keycanc);
                    numcanc = elegruppi.RemoveAll(p => p.ragioneSociale == keycanc);
                    Gruppo.Cancella(keycanc);
                    Data_canc.DataSource = elegruppi.ToList();
                }
                if (rb_disciplina.Checked)
                {
                    eleatleti.RemoveAll(a => a.disciplina.nomeDisciplina == keycanc);
                    numcanc = elediscipline.RemoveAll(p => p.nomeDisciplina == keycanc);
                    Disciplina.Cancella(keycanc);
                    Data_canc.DataSource = elediscipline.ToList();
                }
                if (Rb_atleti.Checked)
                {
                    numcanc = eleatleti.RemoveAll(p => p.codice == keycanc);
                    Atleta.Cancella(keycanc);
                    Funzioni.Select(Data_canc, eleatleti);
                }
                if (numcanc == 0)
                {
                    MessageBox.Show("Nessun elemento trovato.");
                    return;
                }
            }
            else
            {
                foreach (DataGridViewRow r in Data_canc.SelectedRows)
                {
                    if (rb_gruppo.Checked)
                    {
                        eleatleti.RemoveAll(a => a.gruppo.ragioneSociale == r.Cells[0].Value.ToString());
                        numcanc = elegruppi.RemoveAll(p => p.ragioneSociale == r.Cells[0].Value.ToString());
                        Gruppo.Cancella(r.Cells[0].Value.ToString());
                    }

                    if (rb_disciplina.Checked)
                    {
                       eleatleti.RemoveAll(a => a.disciplina.nomeDisciplina == r.Cells[0].Value.ToString());
                       numcanc = elediscipline.RemoveAll(p => p.nomeDisciplina == r.Cells[0].Value.ToString());
                       Disciplina.Cancella(r.Cells[0].Value.ToString());
                    }

                    if (Rb_atleti.Checked) 
                    { 
                        numcanc = eleatleti.RemoveAll(p => p.codice == r.Cells[0].Value.ToString());
                        Atleta.Cancella(r.Cells[0].Value.ToString());
                    }

                    if (numcanc == 0)
                    { 
                        MessageBox.Show("Nessun elemento trovato.");
                        return;
                    }
                }
            }
            if (rb_gruppo.Checked) Data_canc.DataSource = elegruppi.ToList();
            if (rb_disciplina.Checked) Data_canc.DataSource = elediscipline.ToList();
            if (Rb_atleti.Checked) Funzioni.Select(Data_canc, eleatleti);
            Txt_canc.Clear();
        }

        private void Btn_filtri_Click(object sender, EventArgs e)
        {
            List<Atleta> elefiltered = new List<Atleta>();
            elefiltered = eleatleti;
            if (!(combo_view_disciplina.Text == "Tutto"))
            {
                elefiltered = elefiltered.Where(p => p.disciplina.nomeDisciplina == combo_view_disciplina.Text).ToList();
            }
            if (!(combo_view_livello.Text == "Tutto"))
            {
                elefiltered = elefiltered.Where(p => string.Compare(p.livello,combo_view_livello.Text) >= 0).ToList();
            }
            if (!(combo_view_gruppo.Text == "Tutto"))
            {
                elefiltered = elefiltered.Where(p => p.gruppo.ragioneSociale == combo_view_gruppo.Text && p.idoneità == true).OrderBy(p=> p.disciplina.nomeDisciplina).ToList();
            }
            Funzioni.Select(data_visualizza, elefiltered);
        }
        private void Btn_Nofiltro_Click(object sender, EventArgs e)
        {
            combo_view_disciplina.Text = "Tutto";
            combo_view_gruppo.Text = "Tutto";
            combo_view_livello.Text = "Tutto";
            data_visualizza.DataSource = eleatleti.ToList();
        }

        private void Txt_canc_TextChanged(object sender, EventArgs e)
        {
            if (rb_gruppo.Checked == true)
            {
                var zz = elegruppi.Where(p => p.ragioneSociale.ToUpper().Contains(Txt_canc.Text.ToUpper())).ToList();
                Data_canc.DataSource = zz.ToList();
            }
            if (rb_disciplina.Checked == true)
            {
                var zz = elediscipline.Where(p => p.nomeDisciplina.ToUpper().Contains(Txt_canc.Text.ToUpper())).ToList();
                Data_canc.DataSource = zz.ToList();
            }
            if (Rb_atleti.Checked == true)
            {
                var zz = eleatleti.Where(p => p.codice.ToUpper().Contains(Txt_canc.Text.ToUpper())).ToList();
                Funzioni.Select(Data_canc, zz);
            }
        }

        private void Data_canc_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!string.IsNullOrEmpty(Txt_canc.Text))
            {
                Txt_canc.Text = Data_canc.SelectedRows[0].Cells[0].Value.ToString();
            }
        }
    }
}