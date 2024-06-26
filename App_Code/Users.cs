using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Users
/// </summary>
public class Users
{
   private int Id;
    private string Name;
    private string LastName;
    private string Phone;
    private int NumCity;
    private string ThisDate;
    private string Pass;
    private string DateB;
    private int Gender;
    private int Weight;
    private int Height;
    private int LevelStart;
    private int goal;
    private int Trainer;
    private int rank;
    private int itkadmot;
    public Users(int Id, string Name, string LastName,string Phone, int NumCity, string ThisDate, string Pass, string DateB, int Gender, int Weight, int Height, int LevelStart, int goal, int Trainer,int rank,int itkadmot)
    { 
        this.Name = Name;
        this.Id = Id;
        this.LastName = LastName;
        this.Pass = Pass;
        this.Phone = Phone;
        this.NumCity = NumCity;
        this.ThisDate = ThisDate;
        this.DateB = DateB;
        this.Gender = Gender;
        this.Weight = Weight;
        this.Height = Height;
        this.LevelStart = LevelStart;
        this.goal = goal;
        this.Trainer = Trainer;
        this.rank = rank;
        this.itkadmot= itkadmot;
    }

    public Users()
    {
        this.Id = 0;
    }
    public string GetDateB
    {
        get { return DateB; }
        set {DateB = value; }
    }
    public int GetId
    {
        get { return Id; }
        set { Id = value; }
    }
    public int GetItakdmot
    {
        get { return itkadmot; }
        set { itkadmot = value; }
    }
    public string GetName
    {
        get { return Name; }
        set { Name = value; }
    }
    public string ThisDateGet
    {
        get { return ThisDate; }
        set { ThisDate= value; }
    }
    public string GetPassword
    {
        get { return Pass; }
        set { Pass = value; }
    }
    public int GetGender
    {
        get { return Gender; }
        set { Gender = value; }
    }
    public int GetNumCity
    {
        get { return NumCity; }
        set { NumCity = value; }
    }
    public string GetLastName
    {
        get { return LastName; }
        set { LastName = value; }
    }
    public string GetPhone
    {
        get { return Phone; }
        set { Phone = value; } }
    public int GetStartLevel
    { 
        get
        {
            return LevelStart;
        }
        set { LevelStart = value; }
    }
    public int GetWeight
    {
        get { return Weight; }
        set { Weight = value; }
    }
    public int GetHeight
    {
        get { return Height; }
        set { Height = value; }
    }
    public int GetGoal
    {
        get { return goal; }
        set { goal = value; }
    }
    public int GetTrainer
    {
        get { return Trainer; }
        set { Trainer = value; }
    }
    public int GetRank
    {
        get { return rank; }
        set { rank = value; }
    }

}