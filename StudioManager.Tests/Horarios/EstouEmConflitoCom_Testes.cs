using NUnit.Framework;
using StudioManager.Domain;
using StudioManager.Domain.Reservas;

namespace StudioManager.Tests.Horarios
{
    public class EstouEmConflitoCom_Testes
    {
        [SetUp] 
        public void SetUp() 
        {

        }

        [Test]
        public void Test()
        {
            var meuHorario = new Horario(
                new DateTime(2023,12,05,22,00,00),
                new DateTime(2023,12,05,23,00,00));

            var horarioConflituoso1 = new Horario(
                new DateTime(2023,12,05,21,30,00),
                new DateTime(2023,12,05,22,30,00));

            var horarioConflituoso2 = new Horario(
                new DateTime(2023,12,05,21,30,00),
                new DateTime(2023,12,05,23,30,00));

            var horarioConflituoso3 = new Horario(
                new DateTime(2023,12,05,22,00,00),
                new DateTime(2023,12,05,22,30,00));

            var horarioConflituoso4 = new Horario(
                new DateTime(2023,12,05,22,00,00),
                new DateTime(2023,12,05,23,00,00));

            var horarioConflituoso5 = new Horario(
                new DateTime(2023,12,05,22,30,00),
                new DateTime(2023,12,05,23,00,00));

            var horarioConflituoso6 = new Horario(
                new DateTime(2023,12,05,22,30,00),
                new DateTime(2023,12,05,23,30,00));

            var horarioSemConflito1 = new Horario(
                new DateTime(2023,12,05,21,30,00),
                new DateTime(2023,12,05,22,00,00));

            var horarioSemConflito2 = new Horario(
                new DateTime(2023,12,05,21,30,00),
                new DateTime(2023,12,05,21,50,00));

            var horarioSemConflito3 = new Horario(
                new DateTime(2023,12,05,23,00,00),
                new DateTime(2023,12,05,23,50,00));

            var horarioSemConflito4 = new Horario(
                new DateTime(2023,12,05,23,10,00),
                new DateTime(2023,12,05,23,50,00));

            Assert.IsTrue(meuHorario.EstouEmConflitoCom(horarioConflituoso1));
            Assert.IsTrue(meuHorario.EstouEmConflitoCom(horarioConflituoso2));
            Assert.IsTrue(meuHorario.EstouEmConflitoCom(horarioConflituoso3));
            Assert.IsTrue(meuHorario.EstouEmConflitoCom(horarioConflituoso4));
            Assert.IsTrue(meuHorario.EstouEmConflitoCom(horarioConflituoso5));
            Assert.IsTrue(meuHorario.EstouEmConflitoCom(horarioConflituoso6));

            Assert.IsFalse(meuHorario.EstouEmConflitoCom(horarioSemConflito1));
            Assert.IsFalse(meuHorario.EstouEmConflitoCom(horarioSemConflito2));
            Assert.IsFalse(meuHorario.EstouEmConflitoCom(horarioSemConflito3));
            Assert.IsFalse(meuHorario.EstouEmConflitoCom(horarioSemConflito4));
        }
    }
}
