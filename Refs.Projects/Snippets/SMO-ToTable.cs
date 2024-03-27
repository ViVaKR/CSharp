
private void 테이블_목록작성()
{
    콤보_테이블선택.Properties.Items.Clear();
    foreach (Table item in database.Tables)
    {
        콤보_테이블선택.Properties.Items.Add(item.Name);
    }
}

// 테이블 만들기
private void Btn_NewTable_Click(object sender, EventArgs e)
{
    try
    {
        if (database == null)
        {
            XtraMessageBox.Show("테이블을 작성할 데이터베이스를 선택하여 주세요", "안내");
            콤보_데이터베이스선택.ShowPopup();
            return;
        }

        // 테이블 생성
        table = new Table(database, tableName);

        column = new Column(table, "Id", DataType.Int)
        {
            Identity = true,
            Nullable = false,
            IdentityIncrement = 1,
            IdentitySeed = 0
        };
        table.Columns.Add(column);

        column = new Column(table, "Name", DataType.NVarChar(20))
        {
            Nullable = false
        };
        table.Columns.Add(column);

        column = new Column(table, "Age", DataType.TinyInt)
        {
            Nullable = false
        };
        table.Columns.Add(column);

        // Primary Key Index 작성 (1형)
        string pkName = "PK_" + tableName;
        Index idx = new Index(table, pkName);
        table.Indexes.Add(idx); // 테이블 생성전
        IndexedColumn icol = new IndexedColumn(idx, "Id");
        idx.IndexedColumns.Add(icol);
        idx.IsClustered = true; // 클러스터형: 테이블당 하나만 작성 가능
        idx.IsUnique = true;
        idx.IndexKeyType = IndexKeyType.DriPrimaryKey;

        table.AnsiNullsStatus = true;
        table.Create();

        SetMessage("테이블 " + table.Name + " 생성되었습니다.");

        테이블_목록작성();
    }
    catch (SmoException ex)
    {
        SetMessage(ex.Message);
    }
    catch (Exception ex)
    {
        SetMessage(ex.Message);
    }
}
