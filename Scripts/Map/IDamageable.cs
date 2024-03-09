using Godot;
using System;

public interface IDamageable
{
	/// <summary>
	/// Give damage to object
	/// </summary>
	/// <param name="damage"></param>
	public void DoDamage(int damage);

	/// <summary>
	/// Heal object
	/// </summary>
	/// <param name="heal"></param>
	public void DoHeal(int heal);

}
