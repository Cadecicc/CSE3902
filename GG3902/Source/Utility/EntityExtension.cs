namespace GG3902
{
    public static class EntityExtension
    {
        public static void DeleteSelf(this IEntity entity)
        {
            EntityManager.Instance.RemoveEntity(entity.Id);
        }
    }
}
