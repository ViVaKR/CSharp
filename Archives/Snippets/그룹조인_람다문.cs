{
    var 결과목록 = _Db.일지
    .Where(x => x.번호 == _임시번호)
    .GroupJoin(_Db.정의, j => j.코스, c => c.번호, (j, c) => new { Key = j.정의.구분, _거리 = j.거리 }).ToList();

    var tmp = myCollection.GroupBy(x => x.Id).Select(y => new { Id = y.Key, Quantity = y.Sum(x => x.Quantity) });

    var items = db.CREDITO
                .Join(db.BENEFICIARIO, cr => cr.CDBENEFICIARIO, bn => bn.CDBENEFICIARIO, (cr, bn) => new { cr, bn })
                .GroupBy(x => new { x.bn.DEUF, x.bn.DESUPERINTENDENCIAREGIONAL, x.cr.SITUACAODIVIDA })
                .Select(g => new
                {
                    g.Key.DEUF,
                    g.Key.DESUPERINTENDENCIAREGIONAL,
                    g.Key.SITUACAODIVIDA,
                    VLTOTAL = g.Sum(x => x.cr.VLEFETIVAMENTELIBERADO),
                    Count = g.Count()
                })
                .ToList();
}
