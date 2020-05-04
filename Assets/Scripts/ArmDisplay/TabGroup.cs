using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the content displayed by the tabs in the arm display.
// It switches the info shown based on the button selected.

public class TabGroup : MonoBehaviour
{
    // List of buttons present on the tab.
    List<TabButton> tabButtons;
    
    // Template color for the button not in focus.
    public ColorVariable tabIdle;
    
    // Template color for the button in focus.
    public ColorVariable tabSelect;
    
    // The current tab selected.
    public TabButton selectedTab;
    
    // The list of content to be displayed.
    public List<GameObject> contentPages;

    public void Subscribe(TabButton _button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(_button);
    }

    public void OnTabEnter(TabButton _button)
    {
        ResetTabs();
        if (selectedTab == null || _button != selectedTab)
        {
            _button.background.color = tabSelect.color;
        }
    }

    public void OnTabExit(TabButton _button)
    {
        ResetTabs();
        
    }

    public void OnTabSelected(TabButton _button)
    {
        //if(selectedTab != null)
        //{
        //    selectedTab.Deselect();
        //}
        selectedTab = _button;

        //selectedTab.Select();

        ResetTabs();
        _button.background.color = tabSelect.color;

        int index = _button.transform.GetSiblingIndex();
        for (int i = 0; i < contentPages.Count; i++)
        {
            if(i == index)
            {
                contentPages[i].SetActive(true);
            }
            else
            {
                contentPages[i].SetActive(false);
            }
        }

    }

    public void ResetTabs()
    {
        foreach(TabButton _button in tabButtons)
        {
            if (selectedTab != null && _button == selectedTab) { continue; }
            _button.background.color = tabIdle.color;
        }
    }
}
