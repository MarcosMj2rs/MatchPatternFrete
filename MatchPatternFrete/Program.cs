using MatchPatternFrete.Rules;

Console.WriteLine("\nPattern Matching com is e switch\n");

Console.ReadKey();

//Definfindo algumas entregas...
var entregas = new EntregaRule.Entrega[]
{
	new EntregaRule.RetiraNaloja(),
	new EntregaRule.EntregaExpressa(15),
	new EntregaRule.EntregaExpressa(35),
	new EntregaRule.EntregaAgendada(DateTime.Today.AddDays(1)), // vai variar, dias da semana
	new EntregaRule.EntregaAgendada(new DateTime(2025, 8, 10)) // omingo
};

foreach (var entrega in entregas)
{
	var valor = EntregaRule.CalcularFrete(entrega);
	Console.WriteLine($"Entrega: {entrega,-70} -> Frete: {valor:C}");
}
