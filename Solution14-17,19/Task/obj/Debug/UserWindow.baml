   M S B A M L   `   `   `  ����?  ;Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Task.WindowsTask.Windows  5   	       Task.Windows.UserWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Task.Windows     5   	   -   5          �Name$  
WindowUser��5   	    � Title$ 
UserWindow��5   	   $	��450��6   $	��800��6)   ���	#FF11A9DD.��5	      � -   5         �Name$ gUsers��5	      .+�5
   
   �� -   5         ��Name$ lState��5
      $�� ��6!   $��86,22,105,0q�6-   $	��Top=�6B   
�������$��24(�6m    J� RenderTransformOrigin$ 0.525,0.595&�6{   �� 5   
   -   5         ��Name$ tbName��5       �� 	MaxLength$ 50��6"   $
��Left=�61   $��23��6L   $��340,112,0,0q�6X    �� TextWrapping$
 Wrap=�6m   $	��Top=�6�   $	��141��6�   .��6�   ��5      �� 5       �� Path$
 Name�6   	 �� ValidationRules	 5      5  /System.Windows.Controls.DataErrorValidationRule  5      5      .��5      5      �� 5   
   -   5        $ tbBirthDate��5      $
��Left=�6(   $��23��6C   $��340,196,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��141��6�   .��6�   ��5      �� 5      $
 Name�6   	 5        5      5      .��5      5      �� 5   
   -   5        $ tbSecondName��5      $ 50��6(   $
��Left=�67   $��23��6R   $��340,153,0,0q�6^   $
 Wrap=�6s   $	��Top=�6�   $	��141��6�   .��6�   ��5      �� 5      $
 Name�6   	 5         5!      5#      .��5$      5%      �� 5&   
   -   5        $ lName��5&      $��Имя��6   $
��Left=�6-   $��209,104,0,0q�6H   $	��Top=�6]   ���	#00000000$��14(�6�   
�������6�   �� 5'   
   -   5        $ lSecondName��5'      $��Фамилия��6%   $
��Left=�67   $��209,145,0,0q�6R   $	��Top=�6g   ���	#00000000$��14(�6�   
�������6�   �� 5(   
   $��Label��6   $
��Left=�6    $��4��6;   $��220,237,0,0q�6F   $	��Top=�6[   $��0��6s   �� 5)   
   -	   5        $ 
lBirthDate��5)      $��Дата рождения��6$   $
��Left=�6<   $��209,196,0,0q�6W   $	��Top=�6l   ���	#00000000$��14(�6�   
�������6�   �� 5*   
   -
   5        
 ��Name$
 bAction��5*      $��Button��6"   $��667,346,36,35q�63   $ 
1.591,4.81&�6J   9� 5+   
   -   5         9�Name$ eMainWindowRewards��5+      $
��Left=�60   $	��144��6K   $��507,109,0,0q�6X   $	��Top=�6m   $	��180��6�   ��5,      �� 5-      -   5        $
 bWindowRewards��5-      
�������$��14(�6Z   ��61   Z� .��6h   Награды6q   .��5/      � -   5        $ gWindowRewards��5/      ���	#FFE5E5E5.+�50      �� -   5         ��Name$ spWindowRewards��50      .+�51      �� -   5         ��Name$ tmWindowRewardsTitle��51       !Выберите награду6P   52      53      54      55      56      