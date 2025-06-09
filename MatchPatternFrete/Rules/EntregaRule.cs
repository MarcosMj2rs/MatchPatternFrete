namespace MatchPatternFrete.Rules
{
	public static class EntregaRule
	{
		public abstract record Entrega;

		public record RetiraNaloja() : Entrega;

		public record EntregaExpressa(double distanciaKm) : Entrega;

		public record EntregaAgendada(DateTime dataAgendada) : Entrega
		{
			public override string ToString() => $"Entrega Agendada (Data: ) {dataAgendada:dddd, dd MMM, yyyy})";
		}

		public static decimal CalcularFrete(Entrega entrega)
		{
			return entrega switch
			{
				RetiraNaloja => 0m,
				EntregaExpressa(var km) when km < 20 => 15m,
				EntregaExpressa(var km) => 25m + (decimal)(km - 20) * 1.5m,//frete escalonado
				EntregaAgendada { dataAgendada: var data } when data.DayOfWeek == DayOfWeek.Sunday => 50m,
				EntregaAgendada => 20m,
				_ => throw new ArgumentException("Tipo de entrega desconhecido.")
			};
		}
	}
}
