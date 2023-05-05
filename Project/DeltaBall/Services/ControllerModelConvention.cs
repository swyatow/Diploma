using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeltaBall.Services
{
    public class ControllerModelConvention : IControllerModelConvention
    {
        private readonly string _area;
        private readonly string _policy;

        public ControllerModelConvention(string area, string policy)
        {
            _area = area;
            _policy = policy;
        }

        public void Apply(ControllerModel controller)
        {
            if (
                // Если у контоллера есть атрибут, показывающий область этого контроллера,
                // и он равен переданому в конструкторе значению
                controller.Attributes.Any(a =>
                    a is AreaAttribute && (a as AreaAttribute).RouteValue.Equals(_area, StringComparison.OrdinalIgnoreCase))
                ||
                // Или у маршрута, который вызвал этот контроллер содержит описание области,
                // и эта область равна переданому в конструкторе значению
                controller.RouteValues.Any(r =>
                r.Key.Equals("area", StringComparison.OrdinalIgnoreCase) && r.Value.Equals(_area, StringComparison.OrdinalIgnoreCase)))
            {
                // Тогда мы отправляем пользователя на авторизацию
                controller.Filters.Add(new AuthorizeFilter(_policy));
            }
        }
    }
}
