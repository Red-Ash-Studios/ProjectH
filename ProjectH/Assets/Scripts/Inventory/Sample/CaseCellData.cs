namespace VariableInventorySystem.Sample
{
    public class CaseCellData : IStandardCaseCellData
    {
        public int Id => 0;
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool IsRotate { get; set; }
        public IVariableInventoryAsset ImageAsset { get; }

        public StandardCaseViewData CaseData { get; }

        public CaseCellData(int sampleSeed)
        {
            Width = 2;
            Height = 2;
            ImageAsset = new StandardAsset("Image/chest");
            CaseData = new StandardCaseViewData(8, 8);
        }
    }
}